using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private AudioSource currentTheme;
    private AudioSource currentSound;
    private string currentSoundName;
    public static AudioManager instance;

    void Start(){
        StartTheme("Theme");
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        StartTheme("Theme");
    }
    public void Play( string name)
    {
        // To Play --> FindObjectOfType<AudioManager>().Play("Audio Clip Name");
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if ( s == null)
        {
            Debug.LogError("Clip Name: " + name + " NOT Found");
            return;
        }
        if(currentSound!=null && !currentSound.isPlaying){
            currentSound = null;
            currentSoundName = "";
        }
        if ( currentSound == null)
        {
            currentSound = s.source;
            currentSoundName = name;
            currentSound.Play();
        }
        else
        {
            if(currentSoundName != s.name){
                currentSound.Stop();
                currentSound = s.source;
                currentSoundName = s.name;
                currentSound.Play();
            }
        }
        
    }
    public void StartTheme(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Clip Name: " + name + " NOT Found");
            return;
        }
        Debug.Log("play theme");
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
