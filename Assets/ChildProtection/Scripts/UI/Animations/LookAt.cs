using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    public GameObject lookingObject;
    public Transform lookAtTarget;

    // Update is called once per frame
    void Update()
    {
        lookingObject.transform.LookAt(lookAtTarget);
    }
}
