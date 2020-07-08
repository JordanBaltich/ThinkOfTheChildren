using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearReappear : MonoBehaviour
{

    public SpriteRenderer appearingObject;
    public bool inArea;

    private void Update()
    {
        if (inArea)
        {
            appearingObject.color = Color.clear;
        }
        else
        {
            appearingObject.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inArea = false;
    }
}
