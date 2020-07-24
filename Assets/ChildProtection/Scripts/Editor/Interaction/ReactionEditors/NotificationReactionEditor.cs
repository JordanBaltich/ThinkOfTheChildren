using UnityEditor;

[CustomEditor(typeof(NotificationReaction))]
public class NotificationReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Notification Reaction";
    }
}
