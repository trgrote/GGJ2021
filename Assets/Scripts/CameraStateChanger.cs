using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Translate Event calls into Animator Triggers
public class CameraStateChanger : MonoBehaviour
{
    public Animator _animator;

    public void OnStateChange_Falling()
    {
        _animator.SetTrigger("StateChange_Falling");
    }
}
