using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.AI;

public class DestinationTracker : MonoBehaviour
{
    public ParticleSystem burstPartical;
    public ParticleSystem constantPartical;
    SpriteRenderer sr;
    public PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(Vector3 location)
    {
        transform.position = location;
        if (!constantPartical.isPlaying)
        {
            sr.enabled = true;
            burstPartical.Play();
            constantPartical.Play();
        }

    }

    public void OnStop()
    {
        sr.enabled = false;
        constantPartical.Stop();
    }
}
