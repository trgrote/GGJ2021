using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnchorMovement : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        GetComponent<Rigidbody2D>().velocity = value * 2;
    }
}
