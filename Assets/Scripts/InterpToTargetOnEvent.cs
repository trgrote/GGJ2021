using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move Kinematic Body to position
public class InterpToTargetOnEvent : MonoBehaviour
{
    [SerializeField] Rigidbody2D _body;
    [SerializeField] Transform _position;
    [SerializeField] float _time;

    [SerializeField] AnimationCurve _curve;

    public void StartInterp()
    {
        StartCoroutine(MoveTo());
    }

    IEnumerator MoveTo()
    {
        var startPos = _body.position;
        var goalPos = _position.position;
        var time = 0f;

        while (time < _time)
        {
            yield return new WaitForFixedUpdate();
            time += Time.fixedDeltaTime;
            var position = Vector3.Lerp(startPos, goalPos, _curve.Evaluate(time / _time));
            _body.MovePosition(position);
        }

        _body.MovePosition(goalPos);
    }
}
