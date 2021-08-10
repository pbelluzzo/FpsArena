using UnityEngine;
using UnityEditor;
using Player;

[CustomEditor(typeof(MovementController))]
public class MovementControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MovementController controller = target as MovementController;

        SerializedProperty minYProp = serializedObject.FindProperty("minY");
        SerializedProperty maxYProp = serializedObject.FindProperty("maxY");

        base.OnInspectorGUI();

        GUILayout.BeginHorizontal();

        GUILayout.EndHorizontal();
    }

}
