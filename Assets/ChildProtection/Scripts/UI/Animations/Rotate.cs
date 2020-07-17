using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //public GameObject rotateThis;
    public iTween.EaseType easeType;
    public iTween.LoopType loopType;
	public float speed;

    // Update is called once per frame
    void Update()
    {
        iTween.RotateTo(this.gameObject, iTween.Hash("y", 180, "time", speed, "easetype", easeType, "looptype", loopType));
    }
}
