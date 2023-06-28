using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private bool musicPlayed = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" && !musicPlayed)
        {
            PlayMusic("Theme1");
            Debug.Log("Escena 1");
            musicPlayed = true;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1 && musicPlayed || SceneManager.GetActiveScene().buildIndex == 3 && musicPlayed)
        {
            Debug.Log("Escena 2");
            PlayMusic("Theme2");
            musicPlayed = false;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 && !musicPlayed)
        {
            Debug.Log("Escena 2");
            PlayMusic("Theme3");
            musicPlayed = true;
        }
    }



    public void PlayMusic(string Name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == Name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string Name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == Name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
