using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horiz = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = Vector2.left * horiz * 2;
    }
}
