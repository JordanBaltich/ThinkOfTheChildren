using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Report))]
public class ReportEditor : Editor
{
    private bool[] showInfoSlots = new bool[Journal.numInfoSlots];    // Whether the GUI for each Item slot is expanded.
    private SerializedProperty textDisplayProperty;                // Represents the array of Image components to display the Items.
    private SerializedProperty infoProperty;                           // Represents the array of Items.
    //private SerializedProperty infoDisplayProperty;

    private const string reportProptextDisplayName = "keyInfoDisplays";    // The name of the field that is an array of Image components.
    private const string reportPropInfoName = "keyInfos";              // The name of the field that is an array of Items.
    //private const string journalPropInfoDisplayName = "keyInfoDisplays";

    private void OnEnable()
    {
        // Cache the SerializedProperties.
        textDisplayProperty = serializedObject.FindProperty(reportProptextDisplayName);
        infoProperty = serializedObject.FindProperty(reportPropInfoName);
        //infoDisplayProperty = serializedObject.FindProperty(journalPropInfoDisplayName);
    }


    public override void OnInspectorGUI()
    {
        // Pull all the information from the target into the serializedObject.
        serializedObject.Update();

        // Display GUI for each Item slot.
        for (int i = 0; i < Inventory.numItemSlots; i++)
        {
            ItemSlotGUI(i);
        }

        // Push all the information from the serializedObject back into the target.
        serializedObject.ApplyModifiedProperties();
    }


    private void ItemSlotGUI(int index)
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        // Display a foldout to determine whether the GUI should be shown or not.
        showInfoSlots[index] = EditorGUILayout.Foldout(showInfoSlots[index], "Info slot " + index);

        // If the foldout is open then display default GUI for the specific elements in each array.
        if (showInfoSlots[index])
        {
            EditorGUILayout.PropertyField(textDisplayProperty.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(infoProperty.GetArrayElementAtIndex(index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }
}
