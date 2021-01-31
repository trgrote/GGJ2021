using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRepeaterSpeedController : MonoBehaviour
{
    [SerializeField] BuildingRepeater _buildingRepeater;
    [SerializeField] float _upwardSpeed;
    [SerializeField] float _downwardSpeed;

    public void OnStateChange_Falling()
    {
        _buildingRepeater._speed = _upwardSpeed;
    }

    public void OnStateChange_Falling_IntroDone()
    {
        _buildingRepeater._speed = _downwardSpeed;
    }
}
