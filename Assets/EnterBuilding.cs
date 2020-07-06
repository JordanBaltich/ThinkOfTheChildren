using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;


public class EnterBuilding : MonoBehaviour
{
    public CinemachineVirtualCameraBase m_camera;
    private Collider m_EnterCollider;
    public Collider m_ExitCollider;
    private PlayerMovement playerMove;
    private Collider playerCollider;
    private bool doorClicked;
    private bool matClicked;
    public Transform insideTarget;
    public Transform outsideTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMovement>();
        m_EnterCollider = GetComponent<Collider>();
        playerCollider = playerMove.GetComponent<BoxCollider>(); 
    }

    public void DoorWasClicked()
    {        
        doorClicked = true;
        playerMove.OnLocationGo(insideTarget);
        playerMove.acceptingOnMove = false;
    }

    public void MatWasClicked()
    {
        matClicked = true;
        playerMove.OnLocationGo(outsideTarget);
        playerMove.acceptingOnMove = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider )
        {
            playerMove.acceptingOnMove = true;

            if (doorClicked)
            {
                m_camera.gameObject.SetActive(true);
                doorClicked = false;
            }
            if (matClicked)
            {
                m_camera.gameObject.SetActive(false);
                matClicked = false;
            }
        }
    }

    

}
