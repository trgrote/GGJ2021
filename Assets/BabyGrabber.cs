using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyGrabber : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _grabbles;
    [SerializeField] rho.RuntimeGameObjectSet _weapons;
    [SerializeField] rho.Event _eatEvent;
    [SerializeField] rho.Event _thudEvent;

    // Update is called once per frame
    public void OnBabyCollision(Collider2D collider)
    {
        if (_grabbles.Contains(collider.gameObject))
        {
            Destroy(collider.gameObject);
            _eatEvent.Raise();
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
