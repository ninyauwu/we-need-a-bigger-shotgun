using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum GravityDirection
{
    towards_X,
    towards_Y,
    towards_Z,
    from_Z,
    from_X,
    from_Y
}
public enum GravityMode
{
    Rotational,
    Cardinal
}

public class StaticGravityField : MonoBehaviour
{
    [Tooltip("A Rotational Gravity field's direction is controlled by its rotation.\n\nA Cardinal Gravity field will let you pick one of 6 directions. \nTHIS WILL RESET ITS ROTATION TO 0,0,0!! Use Rotational if you want to rotate the object to control its gravity")]
    public GravityMode Mode;

    [Tooltip("Priority handles the calculation priority of gravity. Fields with Priority 0 will not be applied to an object if the object is inside of a field with priority 1.")]
    public int priority;

    [Tooltip("Facing Direction of the gravity field. Uses the XYZ indicator in Unity's scene view (top right of the scene view) as reference for direction. \n\n(Towards-X would mean the gravity would face towards the red X arrow.)")]
    public GravityDirection GravityFacingDirection = GravityDirection.from_Y; //Use?

    [Tooltip("Gravity strength, Defaults to 1G (9.80665)")]
    public float GravityStrength = 9.80665f;

    private Vector3 _gravityForceDirection;

    private void OnDrawGizmos()
    {
        Gizmos.color = PickColorBasedOnDirection();
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
    private void Awake()
    {
        Color fieldFill = PickColorBasedOnDirection();
        //set gravity force direction
        _gravityForceDirection = SetGravityForceDirection();
        //make debug renderer
        MeshRenderer debugRenderer = GetComponent<MeshRenderer>();
        Material tempMaterial = new Material(debugRenderer.material);
        tempMaterial.color = fieldFill;
        debugRenderer.material = tempMaterial;

        Debug.Log(_gravityForceDirection);
    }
    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(_gravityForceDirection);
    }
    private Vector3 SetGravityForceDirection()
    {
        if (Mode == GravityMode.Cardinal)
        {
            gameObject.transform.rotation = Quaternion.identity;
            switch (GravityFacingDirection)
            {
                case GravityDirection.towards_X:
                    return new Vector3(GravityStrength, 0, 0);
                case GravityDirection.towards_Y:
                    return new Vector3(0, GravityStrength, 0);
                case GravityDirection.towards_Z:
                    return new Vector3(0, 0, GravityStrength);
                case GravityDirection.from_X:
                    return new Vector3(-GravityStrength, 0, 0);
                case GravityDirection.from_Y:
                    return new Vector3(0, -GravityStrength, 0);
                case GravityDirection.from_Z:
                    return new Vector3(0, 0, -GravityStrength);
                default:
                    Debug.LogError("Unknown Gravity Direction"); return -transform.up;
            }
        }
        else
        {
            //MAKE THIS BASED ON A GRAVITY ROTATIONAL VALUE;
            Debug.LogError("Unknown Gravity Direction");
            return -transform.up;
        }
    }

    private Color PickColorBasedOnDirection()
    {
        var opacity = 0.2f;
        if (Mode == GravityMode.Cardinal)
        {
            // Assign colors based  on the selected GravityDirection
            switch (this.GravityFacingDirection)
            {
                case GravityDirection.towards_Y:
                    return new Color(0f, 1f, 0f, opacity);
                case GravityDirection.from_Y:
                    return new Color(1f, 0f, 1f, opacity);
                case GravityDirection.towards_X:
                    return new Color(1f, 0f, 0f, opacity);
                case GravityDirection.from_X:
                    return new Color(0f, 1f, 1f, opacity);
                case GravityDirection.towards_Z:
                    return new Color(0f, 0f, 1f, opacity);
                case GravityDirection.from_Z:
                    return new Color(1f, 1f, 0f, opacity);
            }
        }
        return new Color(1f, 1f, 1f, opacity);
    }
}
