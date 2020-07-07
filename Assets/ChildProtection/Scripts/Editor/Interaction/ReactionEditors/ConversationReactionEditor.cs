using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConversationReaction))]
public class ConversationReactionEditor : ReactionEditor
{/*
    private SerializedProperty conversationProperty;    // Represents the string field which is the NPCconversation to be displayed.

    private const float messageGUILines = 1f;           // How many lines tall the GUI for the message field should be.
    private const float areaWidthOffset = 19f;          // Offset to account for the message GUI being made of two GUI calls.  It makes the GUI line up.
    private const string textReactionPropConversationName = "conversation";
                                                        // The name of the field which is the message to be written to the screen.  


    protected override void Init ()
    {
        // Cache all the SerializedProperties.
        conversationProperty = serializedObject.FindProperty (textReactionPropConversationName);
    }


    protected override void DrawReaction ()
    {
        EditorGUILayout.BeginHorizontal ();
        
        // Display a label whose width is offset such that the TextArea lines up with the rest of the GUI.
        EditorGUILayout.LabelField ("Conversation", GUILayout.Width (EditorGUIUtility.labelWidth - areaWidthOffset));

        // Display an interactable GUI element for the text of the message to be displayed over several lines.
        conversationProperty.objectReferenceValue = EditorGUILayout.TextArea (conversationProperty.objectReferenceValue, GUILayout.Height (EditorGUIUtility.singleLineHeight * messageGUILines));
        EditorGUILayout.EndHorizontal ();
    }
    */

    protected override string GetFoldoutLabel ()
    {
        return "Conversation Reaction";
    }
}
