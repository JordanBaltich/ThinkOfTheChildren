using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public Color someColor;
    public float timeTofade;

    // Update is called once per frame
    void Update()
    {
        iTween.FadeTo(this.gameObject, iTween.Hash(
                        "alpha", 0f,
                        "time", timeTofade,
                        "onCompleteTarget", gameObject,
                        "onComplete", "destroy",
                        "oncompleteparams", this.gameObject)
                    );

    }
}
