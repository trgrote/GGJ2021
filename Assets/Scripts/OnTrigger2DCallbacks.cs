using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTrigger2DCallbacks : MonoBehaviour
{
    [SerializeField] UnityEvent<Collider2D> _event;
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        _event.Invoke(collider);
    }
}
