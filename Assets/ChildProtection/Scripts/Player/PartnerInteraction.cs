using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartnerInteraction : MonoBehaviour
{

    public Image displayImage;
    public bool displayInfo;
    public Transform lookAtCamera;
    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        DisplayText();
        displayImage.transform.LookAt(lookAtCamera);
    }

    private void OnMouseOver()
    {
        displayInfo = true;
    }

    private void OnMouseExit()
    {
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
