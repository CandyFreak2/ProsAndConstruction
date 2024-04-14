using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance; // singleton, this is the only instance of it that will exist

    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioSource singleSoundFXObject;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    /*play a clipped version of a soundfx*/
    public void PlaySoundFXClipped(AudioClip audioClip, Transform spawnTransform, float volume, float startTime, float soundLength)
    {

        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.time = startTime;

        audioSource.Play();

        float clipLength = audioSource.clip.length;//use this to detroy after a set length

        Destroy(audioSource.gameObject, soundLength);// destroy after 0.4 seconds
    }


    /*play the full version of a soundfx*/
    public void PlaySoundFXFull(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
    }

    //if another Single audio clip is playing, it will be cutoff + deleted by the new one
    public void PlaySingle(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        GameObject singleSound = GameObject.FindWithTag("Single");
        if (singleSound != null)
        {
            Destroy(singleSound);
        }
        AudioSource audioSource = Instantiate(singleSoundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.tag = "Single";

        audioSource.clip = audioClip;
        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        if (audioSource.gameObject != null)
        {
            Destroy(audioSource.gameObject, clipLength);
        }
    }
}

//https://www.youtube.com/watch?v=DU7cgVsU2rM tutorial for this code