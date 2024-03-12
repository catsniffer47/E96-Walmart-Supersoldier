using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private AudioSource audioSource;  // Add this variable to reference the AudioSource component

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("MenuMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Add a public method to stop the music
    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void StartMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}