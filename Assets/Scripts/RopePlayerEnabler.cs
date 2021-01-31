using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopePlayerEnabler : MonoBehaviour
{
    [SerializeField] GameObject _introPlayer;
    [SerializeField] GameObject _gameModePlayer;

    public void OnStateChange_Gamemode_TransitionOver()
    {
        // TODO Spawn gamemode player
        _introPlayer.SetActive(false);
        _gameModePlayer.SetActive(true);
    }
}
