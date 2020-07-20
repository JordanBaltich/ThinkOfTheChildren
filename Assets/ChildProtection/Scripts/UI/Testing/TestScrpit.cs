using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is a scrpit to test journal reactions and conditions
public class TestScrpit : MonoBehaviour
{
    public KeyInfo testKeyInfo;
    public Journal journal;
    public ReactionCollection reaction;
    public Interactable interact;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            reaction.React();
            //interact.Interact();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            journal.ScrapNote(testKeyInfo);
        }
    }

}
