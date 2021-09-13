using System;
using UnityEngine;
using UnityEngine.Audio;

// Thanks Brackeys

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake() 
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

        foreach(Sound s in sounds) 
        {
            // If no specified source gameobject, add source to audiomanager object
            if (!s.sourceObj)
                s.source = gameObject.AddComponent<AudioSource>();
            else
                s.source = s.sourceObj.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
        }
    }

    void Start() 
    {
        Play("WildWest_1"); // Temporary workaround for music
    }

    // Play audio by name
    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) 
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }
        s.source.Play();
    }
}