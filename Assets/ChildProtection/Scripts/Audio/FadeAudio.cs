using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAudio : MonoBehaviour
{
    [SerializeField] float fadeTime;

    [SerializeField] AudioSource givenSource;

    IEnumerator routine;

    public void FadeAudioIn(AudioSource givenSource)
    {

        StartCoroutine(FadeVolume(givenSource, 0, 1));
    }

    public void FadeAudioOut(AudioSource givenSource)
    {
        StartCoroutine(FadeVolume(givenSource, 1, 0));
    }

    public void FadeInOrOut(bool toggle)
    {
        if (toggle)
        {
            FadeAudioIn(givenSource);
        }
        else
        {
            FadeAudioOut(givenSource);
        }
    }

    IEnumerator FadeVolume(AudioSource givenSource, float start, float end)
    {
        float time = 0;

        while (time < fadeTime)
        {
            float percent = time / fadeTime;
            givenSource.volume = Mathf.Lerp(start, end, percent);

            time += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}
