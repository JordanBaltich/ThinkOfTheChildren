using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;
using DialogueEditor;

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
        m_camera.gameObject.SetActive(false);
        ConversationManager.OnConversationStarted+= ConverStart;
        ConversationManager.OnConversationEnded += ConverEnd;
    }

    public void ConverStart()
    {
        if (m_camera != null)
        {
            if (m_camera.gameObject.activeInHierarchy && m_camera.enabled == true)
            {
                m_camera.enabled = false;
            }
        }
       
    }

    public void ConverEnd()
    {
        if (m_camera != null)
        {
            if (m_camera.gameObject.activeInHierarchy && m_camera.enabled == false)
            {
                m_camera.enabled = true;
            }
        }
            
    }

    public void DoorWasClicked()
    {        
        doorClicked = true;
        playerMove.OnLocationGo(insideTarget);
        playerMove.DisableMoving();
    }

    public void MatWasClicked()
    {
        matClicked = true;
        playerMove.OnLocationGo(outsideTarget);
        playerMove.DisableMoving();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == playerCollider )
        {
            playerMove.EnableMoving();

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
