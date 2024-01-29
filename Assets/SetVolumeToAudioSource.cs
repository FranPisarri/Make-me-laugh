using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeToAudioSource : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<AudioSource>().volume = VolumeController.Instance.MusicVolume;
    }
    public void SetMusicVolumeTo(float volume)
    {
        gameObject.GetComponent<AudioSource>().volume = volume;

    }
}
