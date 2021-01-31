using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRenderer : MonoBehaviour
{
    [SerializeField] Text _text;
    [SerializeField] Score _score;

    // Update is called once per frame
    void Update()
    {
        _text.text = $"Food Eaten :{_score._score}";
    }
}
