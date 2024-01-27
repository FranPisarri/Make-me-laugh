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
    private float fadeDuration = 1.5f; // Adjust the duration of fade-in and fade-out

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeInAndOut());
        }
    }

    private System.Collections.IEnumerator FadeInAndOut()
    {
        float currentTime = 0;
        float startVolume = 0;

        // Fade In
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 1, currentTime / fadeDuration);
            yield return null;
        }

        // Play specific sound using PlayOneShot after the fade-in
        int randomIndex = Random.Range(0, generalSounds.Length);
        PlayRandomSound(randomIndex);

        // Wait for a moment (adjust this time as needed)
        yield return new WaitForSeconds(1.0f);

        // Fade Out
        currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(1, 0, currentTime / fadeDuration);
            yield return null;
        }

        // Reset volume after fading out
        audioSource.volume = 0;
    }

    private void PlayRandomSound(int number)
    {
        if (generalSounds == null || generalSounds.Length == 0)
        {
            Debug.LogError("No general sound clips assigned.");
            return;
        }
        audioSource.PlayOneShot(generalSounds[number]);
    }

    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        audioSource.volume = volume;
    }
}