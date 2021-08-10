using UnityEngine;
using UnityEditor;
using Combat;

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Health health = target as Health;
        SerializedProperty dieEventProp = serializedObject.FindProperty("dieEvent");

        if(health.isPlayer)
            EditorGUILayout.PropertyField(dieEventProp);

        this.serializedObject.ApplyModifiedProperties();
    }
}
