using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTo : MonoBehaviour
{

    public GameObject folder;
    public Transform openPos;
    public Transform closePos;

    public GameObject exitButton;

    public bool tabsIsOpen;

    public float slideSpeed;

    private void Start()
    {
        exitButton.SetActive(false);
        tabsIsOpen = false;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("pressed");
            if (tabsIsOpen)
            {
                Close();
            }
            else if(tabsIsOpen == false)
            {
                Open();
            }
        }
    }

    public void SpawnCloseArea()
    {
        exitButton.SetActive(true);
    }

    public void Open()
    {
        tabsIsOpen = true;
        iTween.MoveTo(folder, openPos.position, slideSpeed);
        SpawnCloseArea();
        
    }

    public void Close()
    {
        tabsIsOpen = false;
        iTween.MoveTo(folder, closePos.position, slideSpeed);
        exitButton.SetActive(false);

    }
}
