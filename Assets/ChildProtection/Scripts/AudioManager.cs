using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource voice, effects, music, ambient, UI;
    [SerializeField] AudioClip[] voiceClips, effectsClips, musicClips, ambientClips, UIClips;

    void PlayVoiceClip(int index)
    {
        voice.clip = voiceClips[index];
        voice.Play();
    }

    void PlayFXClip(int index)
    {
        effects.clip = effectsClips[index];
        effects.Play();
    }

    void PlayMusicClip(int index)
    {
        music.clip = musicClips[index];
        music.Play();
    }

    void PlayAmbientClip(int index)
    {
        ambient.clip = ambientClips[index];
        ambient.Play();
    }
}
