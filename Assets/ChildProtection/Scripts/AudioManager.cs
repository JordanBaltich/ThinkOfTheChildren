using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource voice, effects, music, ambient, UI;
    [SerializeField] AudioClip[] voiceClips, effectsClips, musicClips, ambientClips, UIClips;



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

    public void PlayVoiceClip(int index)
    {
        voice.clip = voiceClips[index];
        voice.Play();
    }

    public void PlayFXClip(int index)
    {
        effects.clip = effectsClips[index];
        effects.Play();
    }

    public void PlayMusicClip(int index)
    {
        music.clip = musicClips[index];
        music.Play();
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void PlayAmbientClip(int index)
    {
        ambient.clip = ambientClips[index];
        ambient.Play();
    }

    public void StopAmbient()
    {
        ambient.Stop();
    }
}
