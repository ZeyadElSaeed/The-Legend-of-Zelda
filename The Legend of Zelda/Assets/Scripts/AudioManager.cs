using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private AudioSource currentTheme;
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
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


    public void Play( string clipName)
    {
        // To Play --> FindObjectOfType<AudioManager>().Play( "Audio Clip Name");
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if ( s == null)
        {
            Debug.LogError("Clip Name: " + name + " NOT Found");
            return;
        }
        s.source.Play();
    }

    public void StartTheme(string ThemeName)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Clip Name: " + name + " NOT Found");
            return;
        }

        if ( currentTheme == null)
        {
            currentTheme = s.source;
            currentTheme.loop = true;
            currentTheme.Play();
        }
        else
        {
            currentTheme.Stop();
            currentTheme = s.source;
            currentTheme.loop = true;
            currentTheme.Play();
        }
        

    }

}
