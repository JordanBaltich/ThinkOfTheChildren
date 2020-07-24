using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class MapButton : MonoBehaviour
{
    public PlayerMovement pm;

    public void Start()
    {
        ConversationManager.OnConversationStarted += DisableButton;
        ConversationManager.OnConversationEnded += EnableButton;
    }

    public void DisableButton()
    {
        gameObject.SetActive(false);
    }

    public void EnableButton()
    {
        gameObject.SetActive(true);

        pm = GameObject.FindObjectOfType<PlayerMovement>();
    }

    public void WaitForABit()
    {
        if (pm != null)
        {
            pm.DisableMoving();
            StartCoroutine("WaitingForABit");
        }
       
    }

    IEnumerator WaitingForABit()
    {
        yield return new WaitForSeconds(1f);
        pm.EnableMoving();

    }
}
