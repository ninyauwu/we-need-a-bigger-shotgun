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
        StaticGravityField gravityField = (StaticGravityField)target;
        if (gravityField.Mode == GravityMode.Cardinal)
        {
            ChangeColorBasedOnDirection(gravityField);
        }
        serializedObject.ApplyModifiedProperties();
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
                    renderer.sharedMaterial.color = Color.green;  // Example color for Up
                    break;
                case GravityDirection.from_Y:
                    renderer.sharedMaterial.color = Color.red;    // Example color for Down
                    break;
                case GravityDirection.towards_X:
                    renderer.sharedMaterial.color = Color.blue;   // Example color for Left
                    break;
                case GravityDirection.from_X:
                    renderer.sharedMaterial.color = Color.yellow; // Example color for Right
                    break;
                case GravityDirection.towards_Z:
                    renderer.sharedMaterial.color = Color.cyan;   // Example color for Forward
                    break;
                case GravityDirection.from_Z:
                    renderer.sharedMaterial.color = Color.magenta; // Example color for Backward
                    break;
            }
        }
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
        return new Color(red / 255f, green / 255f, blue / 255f);
    }
}
