using UnityEngine;

public class JournalReaction : DelayedReaction
{
    public KeyInfo keyInfo;

    private Journal infoManager;            // Reference to the component to display the text.


    protected override void SpecificInit()
    {
        infoManager = FindObjectOfType<Journal> ();
    }


    protected override void ImmediateReaction()
    {
        infoManager.MakeNoteOnKeyInfo(keyInfo);
    }
}