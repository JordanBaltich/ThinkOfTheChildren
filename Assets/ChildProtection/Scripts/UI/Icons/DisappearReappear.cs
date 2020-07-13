using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearReappear : MonoBehaviour
{

    public SpriteRenderer appearingObject;

    private void Awake()
    {
        appearingObject.color = Color.clear;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            appearingObject.color = Color.white;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            appearingObject.color = Color.clear;
        }
    }
}
