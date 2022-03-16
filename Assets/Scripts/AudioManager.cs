using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    [Range(0.0f, 1.0f)]
    public static float masterVolume = 1;
    public static float musicVolume = 1;
    public static float sfxVolume = 1;
    public static float fadeDuration = 3;

    // Use this for initialization
    void Awake() {
        // Singleton pattern (making sure object carries through levels as well as not resetting on every scene)
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = (s.source.loop) ? musicVolume * masterVolume : sfxVolume * masterVolume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("MainMenu");
    }

    public void Play(string name, bool fadeIn = false) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogError("couldn't find sound " + name + " in array. Make sure to add it to the AudioManager object!");
            return;
        }
        if (fadeIn) {
            StartCoroutine(FadeIn(s, fadeDuration));
        } else {
            s.Play();
        }
    }

    public void Stop(string name, bool fadeOut = false) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogError("couldn't find sound " + name + " in array. Make sure to add it to the AudioManager object!");
            return;
        }
        if (fadeOut) {
            StartCoroutine(FadeOut(s, fadeDuration));
        } else {
            s.Stop();
        }
    }

    public bool IsPlaying(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
            return s.source.isPlaying;
        else
            return false;
    }

    public void StopAllSounds() {
        foreach (Sound s in sounds) {
            s.Stop();
        }
    }

    private IEnumerator FadeIn(Sound sound, float duration) {
        float endVolume = sound.source.volume;
        sound.source.volume = 0;
        float startTime = Time.time;
        sound.Play();
        while (Time.time - duration <= startTime) {
            sound.source.volume = Mathf.Lerp(0, endVolume, Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator FadeOut(Sound sound, float duration) {
        float startVolume = sound.source.volume;
        float startTime = Time.time;
        while (Time.time - duration <= startTime) {
            sound.source.volume = Mathf.Lerp(startVolume, 0, Time.deltaTime);
            yield return null;
        }
        sound.Stop();
    }
}
