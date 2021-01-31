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

    public void OnStateChange_Gamemode()
    {
        _animator.SetTrigger("StateChange_Gamemode");
    }
}
