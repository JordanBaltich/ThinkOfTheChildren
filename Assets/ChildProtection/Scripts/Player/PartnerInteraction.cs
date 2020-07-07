using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartnerInteraction : MonoBehaviour
{

    public string hoverText;
    public Text displayText;
    public bool displayInfo;
    public Transform lookAtCamera;

    // Update is called once per frame
    void Update()
    {
        DisplayText();
        Clicked();
        displayText.transform.LookAt(lookAtCamera);
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
            displayText.text = hoverText;
            displayText.color = Color.black;
        } else
        {
            displayText.color = Color.clear;
        }
    }

    void Clicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if( Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.GetComponent<Rigidbody>())
                    {
                        PrintName(hit.transform.gameObject);
                    }
                }
            }
        }
    }

    void PrintName(GameObject objectName)
    {
        print(objectName.name);
    }
}
