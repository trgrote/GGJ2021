using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRepeater : MonoBehaviour
{
    public float _speed;
    [SerializeField] float _buildingHeight;
    [SerializeField] Transform[] _buildings;

    public float Offset => -_buildingHeight * (_buildings.Length - 1) / 2;

    void Start()
    {
        // TODO Order buildings from top to bottom
        for (var i = 0; i < _buildings.Length; ++i)
        {
            var buildingTransform = _buildings[i];

            buildingTransform.localPosition = new Vector3(
                0,
                i * _buildingHeight + Offset,
                0
            );
        }
    }

    void Update()
    {
        // return;
        foreach (var buildingTransform in _buildings)
        {
            var newPosition = buildingTransform.localPosition + new Vector3(0, _speed * Time.deltaTime);
            newPosition.y = Mathf.Repeat(newPosition.y - Offset, _buildingHeight * _buildings.Length) + Offset; 
            buildingTransform.localPosition = newPosition;
        }
    }
}
