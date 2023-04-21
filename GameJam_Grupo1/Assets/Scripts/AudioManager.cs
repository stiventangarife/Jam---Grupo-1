using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sounds
{
    public AudioClip main;
    public AudioClip win;
    public AudioClip lose;
}

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    public static AudioManager audioManagerInstance { get; private set; }
    public Sounds sounds;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.clip = sounds.main;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// This function sets the volume of an audio source to 0.8f.
    /// </summary>
    public void VolumeOn()
    {
        _audioSource.volume = 0.8f;
    }

    /// <summary>
    /// This function sets the volume of an audio source to 0.0f, effectively turning it off.
    /// </summary>
    public void VolumeOff()
    {
        _audioSource.volume = 0.0f;
    }

    /// <summary>
    /// This function changes the volume of an audio source by a specified rate.
    /// </summary>
    /// <param name="volumeRate">The amount by which the volume of the audio source will be changed. It
    /// can be a positive or negative float value.</param>
    public void ChangeVolume(float volumeRate)
    {
        _audioSource.volume += volumeRate;
    }

    /// <summary>
    /// The function sets the audio source to play the "win" sound once when called.
    /// </summary>
    public void OnWin()
    {
        _audioSource.loop = false;
        _audioSource.clip = sounds.win;
        _audioSource.Play();
    }

    /// <summary>
    /// This function sets the audio source to play the "lose" sound clip once and not loop.
    /// </summary>
    public void OnLose()
    {
        _audioSource.loop = false;
        _audioSource.clip = sounds.lose;
        _audioSource.Play();
    }
}
