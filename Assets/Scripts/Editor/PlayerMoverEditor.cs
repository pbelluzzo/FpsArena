using UnityEngine;
using UnityEditor;
using Movement;

[CustomEditor(typeof(PlayerMover))]
public class PlayerMoverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PlayerMover mover = target as PlayerMover;
        SerializedProperty characterSpeedProp = serializedObject.FindProperty("characterSpeed");
        SerializedProperty canRunProp = serializedObject.FindProperty("canRun");
        SerializedProperty runMultiplierProp = serializedObject.FindProperty("runMultiplier");
        SerializedProperty canJumpProp = serializedObject.FindProperty("canJump");
        SerializedProperty jumpHeightProp = serializedObject.FindProperty("jumpHeight");
        SerializedProperty canWalkInJumptProp = serializedObject.FindProperty("canWalkInJump");
        SerializedProperty groundCheckProp = serializedObject.FindProperty("groundCheck");
        SerializedProperty groundDistanceProp = serializedObject.FindProperty("groundDistance");
        SerializedProperty groundMaskProp = serializedObject.FindProperty("groundMask");

        EditorGUILayout.PropertyField(characterSpeedProp);
        EditorGUILayout.PropertyField(canRunProp);
        if (canRunProp.boolValue == true)
            EditorGUILayout.PropertyField(runMultiplierProp);

        EditorGUILayout.PropertyField(canJumpProp);
        if (canJumpProp.boolValue == true)
        {
            EditorGUILayout.PropertyField(jumpHeightProp);
            EditorGUILayout.PropertyField(canWalkInJumptProp);
            EditorGUILayout.PropertyField(groundCheckProp);
            EditorGUILayout.PropertyField(groundDistanceProp);
            EditorGUILayout.PropertyField(groundMaskProp);
        }


        this.serializedObject.ApplyModifiedProperties();
    }
}
