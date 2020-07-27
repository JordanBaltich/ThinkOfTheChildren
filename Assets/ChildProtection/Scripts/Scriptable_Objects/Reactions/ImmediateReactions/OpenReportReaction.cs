using UnityEngine;

public class OpenReportReaction : Reaction
{

    private SlideTo openTab;

    protected override void SpecificInit()
    {
        openTab = FindObjectOfType<SlideTo>();
    }

    protected override void ImmediateReaction()
    {
        openTab.Open();
    }
}
