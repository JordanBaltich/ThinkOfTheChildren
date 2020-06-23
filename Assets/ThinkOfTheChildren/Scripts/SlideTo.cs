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

    public float speed;

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
        SpawnCloseArea();
        transform.position = openPos.position;
        
    }

    public void Close()
    {
        tabsIsOpen = false;
        exitButton.SetActive(false);
        transform.position = closePos.position;
    }
}
