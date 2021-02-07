using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyGrabber : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _grabbles;
    [SerializeField] rho.RuntimeGameObjectSet _weapons;
    [SerializeField] rho.Event _eatEvent;
    [SerializeField] rho.Event _thudEvent;

    [SerializeField] Animator _animator;

    [SerializeField] Score _score;

    [SerializeField] float _eatingLength = 5f;


    enum BabyState
    {
        Grabbing = 0,
        Eating
    }

    BabyState _state = BabyState.Grabbing;

    void Start()
    {
        _score._score = 0;
    }

    #region Prop Holding

    [SerializeField] Transform _propHoldTransform;

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
                propRigidBody.isKinematic = false;
            }
            _currentProp = null;
        }

        _state = BabyState.Grabbing;
    }

    #endregion

    #region Eating Coroutine

    IEnumerator _eatingCoroutine;

    IEnumerator Eat()
    {
        yield return new WaitForSeconds(_eatingLength);
        _score._score++;
        
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
        StopCoroutine(_eatingCoroutine);
    }

    #endregion

    public void OnBabyCollision(Collider2D collider)
    {
        if (_state != BabyState.Grabbing)
        {
            return;
        }

        if (_grabbles.Contains(collider.gameObject))
        {
            _state = BabyState.Eating;
            // Destroy(collider.gameObject);
            _animator.SetTrigger("Eat");
            _eatEvent.Raise();
            
            // Move the object to be MY son now
            HoldOnToProp(collider.gameObject);

            StartEating();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_weapons.Contains(collision.gameObject))
        {
            // TODO On Thud, drop thing currently eating
            _thudEvent.Raise();
            DropProp();
        }
    }
}
