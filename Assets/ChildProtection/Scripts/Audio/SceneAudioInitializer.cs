using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudioInitializer : MonoBehaviour
{
    public int ambientIndex, musicIndex;

    // Start is called before the first frame update
    void Start()
    {
        SoundOnOff(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundOnOff(bool isOn)
    {
        if (isOn)
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayAmbientClip(ambientIndex);
            }
        }
        else
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.StopAmbient();

            }
        }
    }
}
