using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyGrabber : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _grabbles;
    [SerializeField] rho.Event _eatEvent;

    // Update is called once per frame
    public void OnBabyCollision(Collider2D collider)
    {
        if (_grabbles.Contains(collider.gameObject))
        {
            Destroy(collider.gameObject);
            _eatEvent.Raise();
        }
    }
}
