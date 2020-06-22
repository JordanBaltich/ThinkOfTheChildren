using UnityEngine;

// This Reaction has a delay but is not a DelayedReaction.
// This is because the TextManager component handles the
// delay instead of the Reaction.
public class JournalReaction : Reaction
{
    public KeyInfo keyInfo;
    public float delay;                         // How long after the React function is called before the text is displayed.


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