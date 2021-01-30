using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRepeater : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _buildingHeight;
    [SerializeField] Transform[] _buildings;

    void Start()
    {
        // TODO Order buildings from top to bottom
        for (var i = 0; i < _buildings.Length; ++i)
        {
            var buildingTransform = _buildings[i];

            buildingTransform.localPosition = new Vector3(
                0,
                i * _buildingHeight - _buildingHeight * (_buildings.Length - 1) / 2,
                0
            );
        }
    }
}
