using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public bool music = false;

    
    void Start()
    {
        if (music)
        {
            gameObject.GetComponent<Slider>().value = VolumeController.Instance.MusicVolume;
            gameObject.GetComponent<Slider>().onValueChanged.AddListener((v) => {
                VolumeController.Instance.SetMusicVolumeTo(v);
            });
        }
        else
        {
            gameObject.GetComponent<Slider>().value = VolumeController.Instance.SFXVolume;
            gameObject.GetComponent<Slider>().onValueChanged.AddListener((v) => {
                VolumeController.Instance.SetSFXVolumeTo(v);
            });
        }
        

    }

}
