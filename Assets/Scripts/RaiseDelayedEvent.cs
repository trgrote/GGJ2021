using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseDelayedEvent : MonoBehaviour
{
    [SerializeField] float _delay;
    [SerializeField] rho.Event _event;

    public void RaiseDelay()
    {
        StartCoroutine(DelayRaise());
    }

    IEnumerator DelayRaise()
    {
        yield return new WaitForSeconds(_delay);
        _event.Raise();
    }
}
