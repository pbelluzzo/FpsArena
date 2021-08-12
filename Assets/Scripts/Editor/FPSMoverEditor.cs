using UnityEngine;
using UnityEditor;
using Characters;

[CustomEditor(typeof(FPSMover))]
public class FPSMoverEditor : MoverEditor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FPSMover mover = target as FPSMover;

        SerializedProperty canJumpProp = serializedObject.FindProperty("canJump");
        SerializedProperty jumpHeightProp = serializedObject.FindProperty("jumpHeight");
        SerializedProperty canWalkInJumptProp = serializedObject.FindProperty("canWalkInJump");
        SerializedProperty groundCheckProp = serializedObject.FindProperty("groundCheck");
        SerializedProperty groundMaskProp = serializedObject.FindProperty("groundMask");

        EditorGUILayout.PropertyField(canJumpProp);
        if (canJumpProp.boolValue == true)
        {
            EditorGUILayout.PropertyField(jumpHeightProp);
            EditorGUILayout.PropertyField(canWalkInJumptProp);
            EditorGUILayout.PropertyField(groundCheckProp);
            EditorGUILayout.PropertyField(groundMaskProp);
        }


        this.serializedObject.ApplyModifiedProperties();
    }
}
