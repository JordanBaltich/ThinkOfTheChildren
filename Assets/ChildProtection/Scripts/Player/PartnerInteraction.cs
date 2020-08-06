using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;

public class PartnerInteraction : MonoBehaviour
{

    public Image displayImage;
    public bool displayInfo;
    public Transform lookAtCamera;
    public Camera playerCamera;
    public bool canMouseOver;

    private void Start()
    {
        ConversationManager.OnConversationStarted += DisableMouseover;
        ConversationManager.OnConversationEnded += EnableMouseover;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayText();
        displayImage.transform.LookAt(lookAtCamera);

    }

    void DisableMouseover()
    {
        canMouseOver = false;
    }

    void EnableMouseover()
    {
        canMouseOver = true;
    }
    private void OnMouseOver()
    {
        if(canMouseOver == true)
            displayInfo = true;
    }

    private void OnMouseExit()
    {
        if (canMouseOver == true)
            displayInfo = false;
    }

    void DisplayText()
    {
        if (displayInfo)
        {
            displayImage.color = Color.white;
        } else
        {
            displayImage.color = Color.clear;
        }
    }

    public void PrintName(GameObject objectName)
    {
        print(objectName.name);
    }
}
