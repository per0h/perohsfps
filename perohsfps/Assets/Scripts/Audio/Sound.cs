using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    [Range(0f,3f)]
    public float pitch;

    [Range(0F,1F)]
    public float spatialBlend;

    public bool loop;

    public GameObject sourceObj = null;
    

    [HideInInspector]
    public AudioSource source;
}
