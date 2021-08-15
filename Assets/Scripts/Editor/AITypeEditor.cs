using UnityEngine;
using UnityEditor;
using Combat;

[CustomEditor(typeof(AIType))]
public class AITypeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AIType type = target as AIType;
        SerializedProperty projectileTagtProp = serializedObject.FindProperty("projectileTag");

        if (type.isRanged)
            EditorGUILayout.PropertyField(projectileTagtProp);

        this.serializedObject.ApplyModifiedProperties();
    }
}

