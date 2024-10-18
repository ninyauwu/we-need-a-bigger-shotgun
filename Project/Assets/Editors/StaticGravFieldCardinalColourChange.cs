using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StaticGravityField))]
public class StaticGravFieldCardinalColourChange : Editor
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
        Debug.Log("the");
        StaticGravityField gravityField = (StaticGravityField)target;
        if (gravityField.Mode == GravityMode.Cardinal)
        {
            
        }
        serializedObject.ApplyModifiedProperties();
    }


}
