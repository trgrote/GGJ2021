using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDespawner : MonoBehaviour
{
    [SerializeField] rho.RuntimeGameObjectSet _allNPCs;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (_allNPCs.Contains(collider.gameObject))
        {
            Destroy(collider.gameObject);
        }
    }
}
