using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//This is a custom editor that modifies the inspector view of the static Gravity field. It hides the "Direction" inspector property if the mode is set to Rotational, and will also set the rotation to 0,0,0.
[CustomEditor(typeof(StaticGravityField))]
public class StatGravFieldDirectionConditionalHide : Editor
{
    SerializedProperty Mode;
    SerializedProperty Direction;
    private void OnEnable()
    {
        Mode = serializedObject.FindProperty(nameof(StaticGravityField.Mode));
        // Cache the properties to avoid duplicate drawing
        Direction = serializedObject.FindProperty(nameof(StaticGravityField.FacingDirection));
    }
    public override void OnInspectorGUI()
    {
        StaticGravityField gravityField = (StaticGravityField)target;
        EditorGUILayout.PropertyField(Mode);

        if (gravityField.Mode == GravityMode.Cardinal)
        {
            EditorGUILayout.PropertyField(Direction);
            gravityField.transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        serializedObject.ApplyModifiedProperties();
        DrawPropertiesExcluding(serializedObject, nameof(StaticGravityField.FacingDirection), nameof(StaticGravityField.Mode));
    }
}
