using UnityEditor;

[CustomEditor(typeof(ReportReaction))]
public class ReportReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Report Reaction";
    }
}
