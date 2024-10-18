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
            ChangeColorBasedOnDirection(gravityField);
        }
        else if (gravityField.Mode == GravityMode.Rotational)
        {
            SetColourBasedOnRotation(gravityField);
        }
        serializedObject.ApplyModifiedProperties();
        DrawPropertiesExcluding(serializedObject, nameof(StaticGravityField.FacingDirection), nameof(StaticGravityField.Mode));
    }
    private void ChangeColorBasedOnDirection(StaticGravityField gravityField)
    {
        // Get the Renderer component of the GameObject
        Renderer renderer = gravityField.GetComponent<Renderer>();

        if (renderer != null)
        {
            // Assign colors based on the selected GravityDirection
            switch (gravityField.FacingDirection)
            {
                case GravityDirection.towards_Y:
                    renderer.material.color = new Color(0f,1f,0f,0.3f);  // Example color for Up
                    break;
                case GravityDirection.from_Y:
                    renderer.material.color = new Color(1f, 0f, 1f, 0.3f);    // Example color for Down
                    break;
                case GravityDirection.towards_X:
                    renderer.material.color = new Color(1f, 0f, 0f, 0.3f);   // Example color for Left
                    break;
                case GravityDirection.from_X:
                    renderer.material.color = new Color(0f, 1f, 1f, 0.3f); // Example color for Right
                    break;
                case GravityDirection.towards_Z:
                    renderer.material.color = new Color(0f, 0f, 1f, 0.3f);   // Example color for Forward
                    break;
                case GravityDirection.from_Z:
                    renderer.material.color = new Color(1f, 1f, 0f, 0.3f); // Example color for Backward
                    break;
            }
        }
    }
    private void SetColourBasedOnRotation(StaticGravityField gravityField)
    {
        Renderer renderer = gravityField.GetComponent<Renderer>();
        renderer.material.color = GetRotationAsRGB(gravityField.gameObject);
    }
    public Color GetRotationAsRGB(GameObject obj)
    {
        // Get the GameObject's rotation
        Vector3 rotation = obj.transform.rotation.eulerAngles;

        // Normalize rotation values from 0-360 to 0-1
        float normalizedX = rotation.x / 360f;
        float normalizedY = rotation.y / 360f;
        float normalizedZ = rotation.z / 360f;

        // Convert normalized values to 0-255 RGB range
        int red = Mathf.RoundToInt(normalizedX * 255);
        int green = Mathf.RoundToInt(normalizedY * 255);
        int blue = Mathf.RoundToInt(normalizedZ * 255);

        // Return as a Unity Color (which takes 0-1 float values for RGB)
        return new Color(red / 255f, green / 255f, blue / 255f, 0.3f);
    }
}
