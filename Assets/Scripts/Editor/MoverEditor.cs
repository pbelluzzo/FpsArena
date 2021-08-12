using UnityEngine;
using UnityEditor;
using Characters;

[CustomEditor(typeof(Mover))]
public class MoverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        Mover mover = target as Mover;

        SerializedProperty characterSpeedProp = serializedObject.FindProperty("characterSpeed");
        SerializedProperty canRunProp = serializedObject.FindProperty("canRun");
        SerializedProperty runMultiplierProp = serializedObject.FindProperty("runMultiplier");


        EditorGUILayout.PropertyField(characterSpeedProp);
        EditorGUILayout.PropertyField(canRunProp);
        if (canRunProp.boolValue == true)
            EditorGUILayout.PropertyField(runMultiplierProp); 

        this.serializedObject.ApplyModifiedProperties();
    }
}