using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    [SerializeField] bool _dirLeft;
    [SerializeField] GameObject[] _npc;
    [SerializeField] float[] _spawnTimes;

    Vector2 Direction {get => new Vector2(_dirLeft ? -1 : 1, 0);}
    
    void SpawnRandomNPC()
    {
        var prefab = _npc[Random.Range(0, _npc.Length)];
        var npc = Instantiate(prefab, transform.position, transform.rotation, transform.parent);
        var movement = npc.GetComponent<CrowdMovement>();
        if (movement)
        {
            Debug.Log("Found");
            movement.Init(Direction);
        }
    }

    IEnumerator SpawnAtRandomIntervals()
    {
        while (true)
        {
            SpawnRandomNPC();
            yield return new WaitForSeconds(_spawnTimes[Random.Range(0, _spawnTimes.Length)]);            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAtRandomIntervals());
    }
}
