using UnityEngine;
using UnityEditor;
using Movement;

[CustomEditor(typeof(AIMover))]
public class AIMoverEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AIMover mover = target as AIMover;


        //SerializedProperty moveTargetProp = serializedObject.FindProperty("moveTarget");

        //EditorGUILayout.PropertyField(moveTargetProp);


        this.serializedObject.ApplyModifiedProperties();
    }
}
