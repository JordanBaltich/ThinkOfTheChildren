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
        if (CheckforValidIndex(index, voiceClips))
        {
            voice.clip = voiceClips[index];
            voice.Play();
        }
       
    }

    public void PlayFXClip(int index)
    {
        if (CheckforValidIndex(index, effectsClips))
        {
            effects.clip = effectsClips[index];
            effects.Play();
        }
       
    }

    public void PlayMusicClip(int index)
    {
        if (CheckforValidIndex(index, musicClips))
        {
            music.clip = musicClips[index];
            music.Play();
        }
       
    }

    public void StopMusic()
    {
        music.Stop();
    }

    public void PlayAmbientClip(int index)
    {
        if (CheckforValidIndex(index, ambientClips))
        {
            ambient.clip = ambientClips[index];
            ambient.Play();
        }
        
    }

    public void StopAmbient()
    {
        ambient.Stop();
    }

    public void PlayUIClip(int index)
    {
        if (CheckforValidIndex(index, UIClips))
        {
            UI.clip = UIClips[index];
            UI.Play();
        }

    }

    bool CheckforValidIndex(int index, AudioClip[] givenClips)
    {

        if (index >= givenClips.Length)
        {
            print("ERROR: Clip at index point does not exists.");
            return false;
        }
        else return true;
    }
}
