using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    /*public static AudioManager Instance;

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
    }*/

    [System.Serializable]
    public class SceneMusic
    {
        public string sceneName;
        public string musicName;
    }
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    public List<SceneMusic> sceneMusicList;
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
        string sceneName = scene.name;

        SceneMusic sceneMusic = sceneMusicList.Find(sm => sm.sceneName == sceneName);
        if (sceneMusic != null)
        {
            PlayMusic(sceneMusic.musicName);
        }
        else
        {
            StopMusic();
        }
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Music Sound Not Found: " + name);
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlaySFX(string name)
    {
        print("se llamo");
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX Sound Not Found: " + name);
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