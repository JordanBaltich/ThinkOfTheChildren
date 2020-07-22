using UnityEngine;

public class ReportReaction : DelayedReaction
{
    public KeyInfo keyInfo;

    private Report infoManager;            // Reference to the component to display the text.


    protected override void SpecificInit()
    {
        infoManager = FindObjectOfType<Report>();
    }


    protected override void ImmediateReaction()
    {
        infoManager.MakeNoteOnKeyInfo(keyInfo);
    }
}