using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaSpooky : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (SoundManager.instance.audioSource.isPlaying)
        {
            SoundManager.instance.StopSound();
        }
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.SoundCall(1);
        }
    }
}
