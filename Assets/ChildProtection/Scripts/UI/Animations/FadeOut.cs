using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        iTween.FadeTo(this.gameObject, 1f, 0f);
    }
}
