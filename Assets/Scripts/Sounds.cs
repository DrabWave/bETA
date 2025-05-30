using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class Sounds : MonoBehaviour
{
    public AudioClip[] sounds;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 0.85f, float p2 = 1.2f)
    {
        audioSource.pitch = Random.Range(p1, p2);
        audioSource.PlayOneShot(clip, volume);
    }

    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
