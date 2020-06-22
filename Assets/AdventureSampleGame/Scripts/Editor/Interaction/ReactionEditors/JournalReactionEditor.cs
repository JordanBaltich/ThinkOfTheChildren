using UnityEditor;

[CustomEditor(typeof(JournalReaction))]
public class JournalReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Journal Reaction";
    }
}
