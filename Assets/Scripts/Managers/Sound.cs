using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 3f)]
    public float pitch;

    private AudioSource audioSource;

    public void setSource(AudioSource source)
    {
        audioSource = source;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
    }

    public AudioSource getSource()
    {
        return audioSource;
    }
}
