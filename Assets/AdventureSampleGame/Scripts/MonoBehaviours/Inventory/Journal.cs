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


    // This function is called by the PickedUpItemReaction in order to add an item to the inventory.
    public void MakeNoteOnKeyInfo(KeyInfo infoToAdd)
    {
        // Go through all the item slots...
        for (int i = 0; i < keyInfo.Length; i++)
        {
            // ... if the item slot is empty...
            if (keyInfo[i] == null)
            {
                // ... set it to the picked up item and set the image component to display the item's sprite.
                keyInfo[i] = infoToAdd;
                infoDescription[i].text = infoToAdd.Description;
                infoDescription[i].enabled = true;
                return;
            }
        }
    }


    // This function is called by the LostItemReaction in order to remove an item from the inventory.
    public void ScrapNote (KeyInfo itemToRemove)
    {
        // Go through all the item slots...
        for (int i = 0; i < keyInfo.Length; i++)
        {
            // ... if the item slot has the item to be removed...
            if (keyInfo[i] == itemToRemove)
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
