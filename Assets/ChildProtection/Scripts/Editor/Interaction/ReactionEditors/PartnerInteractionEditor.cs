using UnityEditor;

[CustomEditor(typeof(PartnerReaction))]
public class PartnerReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Partner Reaction";
    }
}
