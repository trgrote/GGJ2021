using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] AudioSource _introSource;
    [SerializeField] AudioSource _loopedSource;

    // Start is called before the first frame update
    public void StartPlaying()
    {
        _introSource.Play();
        _loopedSource.PlayDelayed(_introSource.clip.length);
    }
}
