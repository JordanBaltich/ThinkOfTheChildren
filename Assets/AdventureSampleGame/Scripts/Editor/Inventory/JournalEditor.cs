using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Journal))]
public class JournalEditor : Editor
{
    private bool[] showInfoSlots = new bool[Journal.numInfoSlots];    // Whether the GUI for each Item slot is expanded.
    private SerializedProperty infoDescriptionProperty;                      // Represents the array of Image components to display the Items.
    private SerializedProperty infoProperty;                           // Represents the array of Items.


    private const string journalPropInfoDescriptionName = "infoDescription";    // The name of the field that is an array of Image components.
    private const string journalPropInfoName = "keyInfo";              // The name of the field that is an array of Items.


    private void OnEnable ()
    {
        // Cache the SerializedProperties.
        infoDescriptionProperty = serializedObject.FindProperty (journalPropInfoDescriptionName);
        infoProperty = serializedObject.FindProperty (journalPropInfoName);
    }


    public override void OnInspectorGUI ()
    {
        // Pull all the information from the target into the serializedObject.
        serializedObject.Update ();

        // Display GUI for each Item slot.
        for (int i = 0; i < Inventory.numItemSlots; i++)
        {
            ItemSlotGUI (i);
        }

        // Push all the information from the serializedObject back into the target.
        serializedObject.ApplyModifiedProperties ();
    }


    private void ItemSlotGUI (int index)
    {
        EditorGUILayout.BeginVertical (GUI.skin.box);
        EditorGUI.indentLevel++;
        
        // Display a foldout to determine whether the GUI should be shown or not.
        showInfoSlots[index] = EditorGUILayout.Foldout (showInfoSlots[index], "Info slot " + index);

        // If the foldout is open then display default GUI for the specific elements in each array.
        if (showInfoSlots[index])
        {
            EditorGUILayout.PropertyField (infoDescriptionProperty.GetArrayElementAtIndex (index));
            EditorGUILayout.PropertyField (infoProperty.GetArrayElementAtIndex (index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical ();
    }
}
