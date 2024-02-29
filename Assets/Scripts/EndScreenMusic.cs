using UnityEngine;

public class EndScreenManager : MonoBehaviour
{
    public AudioSource endScreenAudioSource;  // Reference to the AudioSource component
    public AudioClip endScreenMusic;          // Reference to the AudioClip

    void Start()
    {
        // Check if AudioSource and AudioClip are assigned
        if (endScreenAudioSource != null && endScreenMusic != null)
        {
            // Set the AudioClip for the AudioSource
            endScreenAudioSource.clip = endScreenMusic;
            // Play the audio
            endScreenAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip not assigned for End Screen.");
        }
    }
}