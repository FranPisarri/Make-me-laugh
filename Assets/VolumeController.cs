using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public static VolumeController Instance;


    public float MusicVolume;
    public float SFXVolume;


    private void Awake()
    {
        if (Instance == null)
        {
            VolumeController.Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolumeTo(float volume)
    {
        MusicVolume = volume;
    }
    public void SetSFXVolumeTo(float volume)
    {
        SFXVolume = volume;
    }
}

