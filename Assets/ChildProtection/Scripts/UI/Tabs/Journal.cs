using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Journal : MonoBehaviour
{
    public KeyInfo[] keyInfos = new KeyInfo[numInfoSlots];           // The Items that are carried by the player.
    public KeyInfoDisplay[] keyInfoDisplays = new KeyInfoDisplay[numInfoSlots];    // The components that display the Items.
    public GameObject journalGameObject;
    public bool journalIsDisplayed = false;
    public float scrollSpeed = 2;
    public const int numInfoSlots = 4;                      // The number of items that can be carried.  This is a constant so that the number of Images and Items are always the same.

    private void OnEnable()
    {
        for (int i = 0; i < keyInfos.Length; i++)
        {
            keyInfoDisplays[i].SetUp();
        }
    }

    public void ToggleJournal()
    {
        //journalGameObject.SetActive(!journalGameObject.activeInHierarchy);
        //journalIsDisplayed = journalGameObject.activeInHierarchy;
    }


    // This function is called by the JournalReaction in order to add an imfo to the journal.
    public void MakeNoteOnKeyInfo(KeyInfo infoToAdd)
    {
        // Go through all the item slots...
        for (int i = 0; i < keyInfos.Length; i++)
        {

            // ... if the info is already there
            if (keyInfos[i] == infoToAdd)
            {
                Debug.Log("Info Already Added");
                return;
            }
            // ... if the info slot is empty...
            if (keyInfos[i] == null)
            {
                // ... set it to the picked up info and set the text component to display the info text string.
                keyInfos[i] = infoToAdd;
                keyInfoDisplays[i].WriteNote(keyInfos[i]);
                keyInfoDisplays[i].enabled = true;
                //journalGameObject.SetActive(true);
                journalIsDisplayed = true;
                return;
            }
        }
    }


    // This function is called by the LostItemReaction in order to remove an imfo to the journal.
    public void ScrapNote(KeyInfo infoToRemove)
    {
        // Go through all the item slots...
        for (int i = 0; i < keyInfos.Length; i++)
        {
            // ... if the item slot has the item to be removed...
            if (keyInfos[i] == infoToRemove)
            {
                // ... set the item slot to null and set the image component to display nothing.
                keyInfos[i] = null;
                keyInfoDisplays[i].infoDescription.text = null;
                keyInfoDisplays[i].enabled = false;
                return;
            }
        }
    }
}
