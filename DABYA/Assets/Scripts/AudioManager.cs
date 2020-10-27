using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private System.Random rand = new System.Random();
    private String[] menuMusic = {"MenuOne", "MenuTwo", "MenuThree", "MenuFour"};
    private String[] gameMusic = {"GameOne", "GameTwo", "GameThree", "GameFour" };
    private String currentlyPlaying = null;

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

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        PlayMenuMusic();
    }

    public void Play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
        if (s != null)
        {
            s.source.PlayOneShot(s.clip);
        }
    }

    public void PlayMenuMusic()
    {
        if (currentlyPlaying != null)
        {
            StopPlaying(currentlyPlaying);
        }

        String name = menuMusic[rand.Next(menuMusic.Length)];
        Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
        if (s != null)
        {
            currentlyPlaying = name;
            s.source.Play();
        }
    }

    public void PlayGameMusic()
    {
        if (currentlyPlaying != null)
        {
            StopPlaying(currentlyPlaying);
        }

        String name = gameMusic[rand.Next(gameMusic.Length)];
        Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
        if (s != null)
        {
            currentlyPlaying = name;
            s.source.Play();
        }
    }

    public void StopPlaying(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
        if (s != null)
        {
            s.source.Stop();
        }
    }
}
