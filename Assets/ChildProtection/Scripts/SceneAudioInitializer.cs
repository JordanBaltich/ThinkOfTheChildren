using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAudioInitializer : MonoBehaviour
{
    [SerializeField] int ambientIndex, musicIndex;

    // Start is called before the first frame update
    void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayAmbientClip(ambientIndex);
            AudioManager.Instance.PlayMusicClip(musicIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
