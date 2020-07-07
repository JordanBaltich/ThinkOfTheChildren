using UnityEditor;

[CustomEditor(typeof(NavMovementReaction))]
public class NavMovementReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Nav Movement Reaction";
    }
}
