using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser : MonoBehaviour
{
    [SerializeField] rho.Event _event;

    // Start is called before the first frame update
    public void RaiseEvent()
    {
        _event.Raise();
    }
}
