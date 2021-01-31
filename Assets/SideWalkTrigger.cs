using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalkTrigger : MonoBehaviour
{
    [SerializeField] bool _left;
    [SerializeField] float _pushDistance;

    [SerializeField] rho.RuntimeGameObjectSet _allNPCs;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OnTriggerEnter2D");
        if (_allNPCs.Contains(collider.gameObject))
        {
            var movement = collider.GetComponent<CrowdMovement>();
            if (movement)
            {
                var direction = movement.Direction;

                // If NPC is moving left, and we are handle left moving targets
                // Else If NPC is moving right, and we are handle right moving targets
                if (_left && direction.x < 0 || !_left && direction.x > 0)
                {
                    collider.gameObject.transform.Translate(new Vector3(0, _pushDistance, 0));
                    Physics2D.IgnoreCollision(collider, GetComponent<Collider2D>());
                }
            }
        }
    }
}
