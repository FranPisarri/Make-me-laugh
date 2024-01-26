using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // Add your general sounds here
    public AudioClip[] generalSounds;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) // cuando colisiona con algo entra
    {
        if (other.CompareTag("Player"))// se fija si el tag es "player"
        {
            PlayRandomSound();// reproduce sonido random
        }
    }

    private void PlayRandomSound()
    {
        if (generalSounds == null || generalSounds.Length == 0)
        {
            Debug.LogError("No general sound clips assigned.");
            return;
        }

        int randomIndex = Random.Range(0, generalSounds.Length);
        audioSource.PlayOneShot(generalSounds[randomIndex]);
    }

    public void SetVolume(float volume) // cambia el volumen
    {
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
    }
}