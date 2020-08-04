using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] AudioSource voice, effects, music, ambient, UI, footSteps, footSteps2;
    [SerializeField] AudioClip[] voiceClips, effectsClips, musicClips, ambientClips, UIClips, footStepClips;

    public float pitchRandomizer;

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
            if (!voice.isPlaying)
            {
                voice.clip = voiceClips[index];
                voice.Play();
            }
        }

    }

    public void StopVoice()
    {
        voice.Stop();
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
            if (!UI.isPlaying)
            {
                UI.clip = UIClips[index];
                UI.Play();
            }
        }

    }

    public void StopUI()
    {
        UI.Stop();
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

    public void PlayFootStepClips(CheckTerrainTexture textureCheck, bool isOnTerrain)
    {
        footSteps.pitch = Random.Range(1 - pitchRandomizer, 1 + pitchRandomizer);

        textureCheck.GetTerrainTexture();
        if (isOnTerrain)
        {
            int currentTerrain = 0;

            for (int i = 0; i < textureCheck.textureValues.Length; i++)
            {
                if (textureCheck.textureValues[i] > 0)
                {
                    if (i == 0)
                    {
                        currentTerrain = i;
                    }
                    else
                    {
                        if (textureCheck.textureValues[i] > textureCheck.textureValues[currentTerrain])
                        {
                            currentTerrain = i;
                        }
                    }
                }
            }


            if (currentTerrain == 0)
            {
                if (footSteps.isPlaying)
                {
                    if (!footSteps2.isPlaying)
                        footSteps2.PlayOneShot(footStepClips[(int)Random.Range(0, 6)]);
                    else
                        footSteps.PlayOneShot(footStepClips[(int)Random.Range(0, 6)]);
                }
                else
                footSteps.PlayOneShot(footStepClips[(int)Random.Range(0, 6)]);
            }
            else if (currentTerrain == 1)
            {
                if (footSteps.isPlaying)
                {
                    if (!footSteps2.isPlaying)
                        footSteps2.PlayOneShot(footStepClips[(int)Random.Range(7, 10)]);
                    else
                        footSteps.PlayOneShot(footStepClips[(int)Random.Range(7, 10)]);
                }
                else
                footSteps.PlayOneShot(footStepClips[(int)Random.Range(7, 10)]);
            }
            else if (currentTerrain == 2)
            {
                if (footSteps.isPlaying)
                {
                    if (!footSteps2.isPlaying)
                        footSteps2.PlayOneShot(footStepClips[(int)Random.Range(11, 16)]);
                    else
                        footSteps.PlayOneShot(footStepClips[(int)Random.Range(11, 16)]);
                }
                else
                footSteps.PlayOneShot(footStepClips[(int)Random.Range(11, 16)]);
            }
        }
        else
        {
            if (footSteps.isPlaying)
            {
                if (!footSteps2.isPlaying)
                    footSteps2.PlayOneShot(footStepClips[(int)Random.Range(17, 23)]);
                else
                    footSteps.PlayOneShot(footStepClips[(int)Random.Range(17, 23)]);
            }
            footSteps.PlayOneShot(footStepClips[(int)Random.Range(17, 23)]);
        }

    }
}
