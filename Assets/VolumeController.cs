using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider volumeSlider;

    private SoundManager soundManager;

    private void Start()
    {
        // Find the SoundManager in the scene
        soundManager = GameObject.Find("Sounds").GetComponent<SoundManager>();

        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
            return;
        }

        // Set the initial volume to the slider value
        volumeSlider.value = soundManager.GetVolume();
        // Add a listener to the slider value changed event
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        // Update the volume of the SoundManager when the slider value changes
        soundManager.SetVolume(volume);
    }
}

