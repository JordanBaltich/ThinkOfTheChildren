using UnityEngine;

public class NotificationReaction : Reaction
{
    public GameObject notificationIcon;

    protected override void ImmediateReaction()
    {
        notificationIcon.SetActive(true);
    }
}
