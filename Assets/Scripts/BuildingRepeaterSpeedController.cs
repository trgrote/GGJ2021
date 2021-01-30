using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRepeaterSpeedController : MonoBehaviour
{
    [SerializeField] BuildingRepeater _buildingRepeater;
    [SerializeField] float _upwardSpeed;
    [SerializeField] float _downwardSpeed;

    IEnumerator SpeedTranstiion()
    {
        _buildingRepeater._speed = _upwardSpeed;
        yield return new WaitForSeconds(2.0f);
        _buildingRepeater._speed = _downwardSpeed;
    }

    public void OnStateChange_Falling()
    {
        StartCoroutine(SpeedTranstiion());
    }

}
