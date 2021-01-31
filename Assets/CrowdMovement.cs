using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMovement : MonoBehaviour
{
    Vector2 _direction;
    [SerializeField] float _speed;
    [SerializeField] Spine.Unity.SkeletonMecanim _skeleton;

    void FixedUpdate()
    {
        transform.Translate(_direction * _speed);
    }

    public void Init(Vector2 direction)
    {
        _direction = direction;
        // Flip X is we going right
        if (_direction.x > 0)
        {
            _skeleton.skeleton.ScaleX = -_skeleton.skeleton.ScaleX;
        }
    }
}
