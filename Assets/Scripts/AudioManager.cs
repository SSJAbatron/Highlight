using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public SoundObject[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public void PlayMusic(string musicName)
    {
        SoundObject sound = Array.Find(musicSounds, x => x.AudioClipName == musicName);

        if (sound != null)
        {
            musicSource.clip = sound.AudioClip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string sfxName)
    {
        SoundObject sound = Array.Find(sfxSounds, x => x.AudioClipName == sfxName);

        if (sound != null)
        {
            sfxSource.PlayOneShot(sound.AudioClip);
        }
    }
}
