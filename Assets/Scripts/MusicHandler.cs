using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] AudioSource _introSource;
    [SerializeField] AudioSource _loopedSource;
    [SerializeField] rho.Event _introOverEvent;

    // Start is called before the first frame update
    public void StartPlaying()
    {
        _introSource.Play();
        _loopedSource.PlayDelayed(_introSource.clip.length);
        StartCoroutine(RaiseEventAfterDelay(_introSource.clip.length));
    }

    IEnumerator RaiseEventAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _introOverEvent.Raise();
    }
}
