using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BabyGrabber : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _grabbles;
    [SerializeField] rho.RuntimeGameObjectSet _weapons;
    [SerializeField] rho.RuntimeGameObjectSet _poisons;
    [SerializeField] rho.Event _grabEvent;
    [SerializeField] rho.Event _eatEvent;
    [SerializeField] rho.Event _eatStopEvent;
    [SerializeField] rho.Event _thudEvent;
    [SerializeField] rho.Event _poisonGrabbedEvent;
    [SerializeField] rho.Event _atePoisonEvent;
    [SerializeField] rho.Event _ateFoodEvent;

    [SerializeField] Animator _animator;

    [SerializeField] Score _score;

    [SerializeField] float _eatingLength = 5f;

    [SerializeField] float _propHitForce = 14f;

    enum BabyState
    {
        Grabbing = 0,
        Eating
    }

    BabyState _state = BabyState.Grabbing;

    List<GameObject> _alreadyGrabbed = new List<GameObject>();

    void Start()
    {
        _score._score = 0;
        _alreadyGrabbed.Clear();
    }

    #region Prop Holding

    [SerializeField] Transform _propHoldTransform;
    [SerializeField] LayerMask _layerOnDrop;

    private GameObject _currentProp;

    void HoldOnToProp(GameObject prop)
    {
        if (_currentProp)
        {
            _currentProp.transform.parent = null;
            _currentProp = null;
        }

        var propTransform = prop.transform;
        propTransform.parent = _propHoldTransform;
        propTransform.localPosition = Vector2.zero;
        propTransform.localRotation = Quaternion.identity;

        _currentProp = prop;
    }

    public void DropProp()
    {
        if (_state != BabyState.Eating)
        {
            return;
        }

        if (_currentProp)
        {
            _currentProp.transform.parent = null;
            var propRigidBody = _currentProp.GetComponent<Rigidbody2D>();
            if (propRigidBody)
            {
                // Change the prop to kinematic and turn all colliders to not-triggers
                propRigidBody.isKinematic = false;
                // This could be an issue if some thing are SUPPOSED TO ALWAYS BE TRIGGERS, but rn we don't have any props that are like that
                _currentProp.GetComponents<Collider2D>().ToList().ForEach(c => c.isTrigger = false);
            }
            // Set Layer on drop to ignore collisions except for 'Ground'
            _currentProp.layer = (int) Mathf.Log(_layerOnDrop.value, 2);
            _currentProp = null;
        }
        _eatStopEvent.Raise();
        _state = BabyState.Grabbing;
    }

    #endregion

    #region Eating Coroutine

    IEnumerator _eatingCoroutine = null;

    IEnumerator Eat()
    {
        yield return new WaitForSeconds(_eatingLength);
        _eatStopEvent.Raise();

        // See what we just ate
        if (_poisons.Contains(_currentProp))
        {
            _atePoisonEvent.Raise();
            _score._score--;
        }
        else
        {
            _ateFoodEvent.Raise();
            _score._score++;
        }        
        
        // Destroy the prop, instead of dropping
        Destroy(_currentProp);
        _currentProp = null;

        _state = BabyState.Grabbing;
        _animator.SetTrigger("ReturnToIdle");
    }

    void StartEating()
    {
        StartCoroutine(_eatingCoroutine = Eat());
    }

    void StopEating()
    {
        if (_eatingCoroutine != null)
        {
            StopCoroutine(_eatingCoroutine);
            _eatingCoroutine = null;
        }
    }

    #endregion

    public void OnBabyCollision(Collider2D collider)
    {
        if (_state != BabyState.Grabbing)
        {
            return;
        }

        if (_grabbles.Contains(collider.gameObject) && !_alreadyGrabbed.Contains(collider.gameObject))
        {
            _state = BabyState.Eating;
            // Destroy(collider.gameObject);
            _animator.SetTrigger("Eat");
            _grabEvent.Raise();

            _alreadyGrabbed.Add(collider.gameObject);

            // Check type
            if (_poisons.Contains(collider.gameObject))
            {
                _poisonGrabbedEvent.Raise();
            }
            
            // Move the object to be MY son now
            HoldOnToProp(collider.gameObject);

            StartEating();
            _eatEvent.Raise();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_weapons.Contains(collision.gameObject))
        {            
            _thudEvent.Raise();
            // drop thing currently eating
            DropProp();
            StopEating();

            // Add more impulse to collision
            var normal = collision.relativeVelocity.normalized;
            var rb = GetComponent<Rigidbody2D>();
            rb.AddForce(normal * _propHitForce, ForceMode2D.Impulse);
        }
    }
}
