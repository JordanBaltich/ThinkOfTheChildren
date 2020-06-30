using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;


public class EnterBuilding : MonoBehaviour
{
    public CinemachineVirtualCameraBase m_camera;
    private Collider m_collider;
    private PlayerMovement playerMove;
    private Collider playerCollider;
    private bool inside;
    private bool entering;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMovement>();
        m_collider = GetComponent<Collider>();
        playerCollider = playerMove.GetComponent<BoxCollider>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider)
        {
            if (entering)
                return;

            inside = !inside;
            m_camera.gameObject.SetActive(inside);
            entering = true;
            WaitForABit();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == playerCollider)
        {
            entering = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == playerCollider)
        {
            entering = false;
        }
    }

    public void WaitForABit()
    {
        StartCoroutine("WaitingForABit", entering);
    }

    IEnumerator WaitingForABit(bool b)
    {
        yield return new WaitForSeconds(2f);
        b = false;
    }

}
