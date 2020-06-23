using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Journal : MonoBehaviour
{
    public TMP_Text[] infoDescription = new TMP_Text[numInfoSlots];    // The Image components that display the Items.
    public KeyInfo[] keyInfo = new KeyInfo[numInfoSlots];           // The Items that are carried by the player.
    public GameObject journalGameObject;

    public const int numInfoSlots = 4;                      // The number of items that can be carried.  This is a constant so that the number of Images and Items are always the same.


    public void ToggleJournal()
    {
        journalGameObject.SetActive(!journalGameObject.activeInHierarchy);
    }


    // This function is called by the JournalReaction in order to add an imfo to the journal.
    public void MakeNoteOnKeyInfo(KeyInfo infoToAdd)
    {
        // Go through all the item slots...
        for (int i = 0; i < keyInfo.Length; i++)
        {
            // ... if the info is already there
            if (keyInfo[i] == infoToAdd)
            {
                Debug.Log("Info Already Added");
                return;
            }
            // ... if the info slot is empty...
            if (keyInfo[i] == null)
            {
                // ... set it to the picked up info and set the text component to display the info text string.
                keyInfo[i] = infoToAdd;
                infoDescription[i].text = infoToAdd.Description;
                infoDescription[i].enabled = true;
                return;
            }
        }
    }


    // This function is called by the LostItemReaction in order to remove an imfo to the journal.
    public void ScrapNote (KeyInfo infoToRemove)
    {
        // Go through all the item slots...
        for (int i = 0; i < keyInfo.Length; i++)
        {
            // ... if the item slot has the item to be removed...
            if (keyInfo[i] == infoToRemove)
            {
                // ... set the item slot to null and set the image component to display nothing.
                keyInfo[i] = null;
                infoDescription[i].text = null;
                infoDescription[i].enabled = false;
                return;
            }
        }
    }
}
