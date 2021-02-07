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

    enum BabyState
    {
        Grabbing = 0,
        Eating
    }

    BabyState _state = BabyState.Grabbing;

    [SerializeField] float _eatingLength = 5f;

    IEnumerator _eatingCoroutine;

    void Start()
    {
        _score._score = 0;
    }

    IEnumerator Eat()
    {
        yield return new WaitForSeconds(_eatingLength);
        _score._score++;
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

    public void OnBabyCollision(Collider2D collider)
    {
        if (_state != BabyState.Grabbing)
        {
            return;
        }

        if (_grabbles.Contains(collider.gameObject))
        {
            _state = BabyState.Eating;
            Destroy(collider.gameObject);
            _animator.SetTrigger("Eat");
            _eatEvent.Raise();
            StartEating();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_weapons.Contains(collision.gameObject))
        {
            _thudEvent.Raise();
        }
    }
}
