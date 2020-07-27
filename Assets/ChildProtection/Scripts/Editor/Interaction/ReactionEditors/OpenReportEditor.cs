using UnityEditor;

[CustomEditor(typeof(OpenReportReaction))]
public class OpenReportReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Open Report Reaction";
    }
}