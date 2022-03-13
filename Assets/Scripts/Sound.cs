using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;
    public AudioClip clip;
    public bool loop;

    [Range(0, 1)]
    public float volume;
    [Range(0.1f, 3)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool isPlaying {
        get {
            return source ? source.isPlaying : false;
        }
    }

    public void Play() {
        source?.Play();
    }

    public void Stop() {
        source?.Stop();
    }
}