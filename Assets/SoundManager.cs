using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // Scene-specific sound mappings
    public AudioClip[] MenuSounds;
    public AudioClip[] GameSounds;

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

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Adjust sound mappings based on the loaded scene
        switch (scene.buildIndex)
        {
            case 1:
                audioSource.clip = null; // Reset clip in case it was playing
                audioSource.clip = GetRandomSound(MenuSounds);
                break;
            case 2:
                audioSource.clip = null;
                audioSource.clip = GetRandomSound(GameSounds);
                break;
                // Add more cases for additional scenes
        }
    }

    private AudioClip GetRandomSound(AudioClip[] soundArray)
    {
        if (soundArray == null || soundArray.Length == 0)
        {
            Debug.LogError("No sound clips assigned for the current scene.");
            return null;
        }

        int randomIndex = Random.Range(0, soundArray.Length);
        return soundArray[randomIndex];
    }

    public void PlayCurrentSceneSound()
    {
        if (audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        else
        {
            Debug.LogWarning("No sound assigned for the current scene.");
        }
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
    }
}

//Call SoundManager.instance.PlayCurrentSceneSound() whenever you want to play the scene-specific sound