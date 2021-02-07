using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class AnchorMovement : MonoBehaviour
{
    [SerializeField] Vector2 _minValues, _maxValues;
    Rigidbody2D _rigidBody2d;

    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        var newVelocity = value * 5;
        _rigidBody2d.velocity = newVelocity;
    }

    void Start()
    {
        _rigidBody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var position = transform.localPosition;
        var newVelocity = _rigidBody2d.velocity;
        var changeRequried = false;

        // Check to make sure we are in bounds, and it not, don't let change go FURTHER out of bounds
        if (position.x <= _minValues.x)
        {
            newVelocity.x = Mathf.Clamp(newVelocity.x, 0, Mathf.Infinity);
            changeRequried = true;
        }
        else if(position.x >= _maxValues.x)
        {
            newVelocity.x = Mathf.Clamp(newVelocity.x, Mathf.NegativeInfinity, 0);
            changeRequried = true;
        }

        if (position.y <= _minValues.y)
        {
            newVelocity.y = Mathf.Clamp(newVelocity.y, 0, Mathf.Infinity);
            changeRequried = true;
        }
        else if(position.y >= _maxValues.y)
        {
            newVelocity.y = Mathf.Clamp(newVelocity.y, Mathf.NegativeInfinity, 0);
            changeRequried = true;
        }

        if (changeRequried)
        {
            _rigidBody2d.velocity = newVelocity;
        }
    }
}
