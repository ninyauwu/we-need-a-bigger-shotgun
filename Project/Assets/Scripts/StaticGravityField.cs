using System.Collections;
using System.Collections.Generic;
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

    [Tooltip("Facing Direction of the gravity field. Uses the XYZ indicator in Unity's scene view (top right of the scene view) as reference for direction. \n\n(Towards-X would mean the gravity would face towards the red X arrow.)")]
    public GravityDirection FacingDirection = GravityDirection.from_Y; //Use?

    [Tooltip("Gravity strength, Defaults to 1G (9.80665)")]
    public float GravityStrength = 9.80665f;

    private Vector3 _gravityForceDirection;

    // Start is called before the first frame update
    void Start()
    {
        if (Mode == GravityMode.Cardinal)
        {
            gameObject.transform.rotation = Quaternion.identity;
            switch (FacingDirection)
            {
                case GravityDirection.towards_X:
                    _gravityForceDirection = new Vector3(GravityStrength, 0, 0); break;
                case GravityDirection.towards_Y:
                    _gravityForceDirection = new Vector3(0, GravityStrength, 0); break;
                case GravityDirection.towards_Z:
                    _gravityForceDirection = new Vector3(0, 0, GravityStrength); break;
                case GravityDirection.from_X:
                    _gravityForceDirection = new Vector3(-GravityStrength, 0, 0); break;
                case GravityDirection.from_Y:
                    _gravityForceDirection = new Vector3(0, -GravityStrength, 0); break;
                case GravityDirection.from_Z:
                    _gravityForceDirection = new Vector3(0, 0, -GravityStrength); break;
            }
        }
        else
        {
            
            _gravityForceDirection = -transform.up;
        }
        
    }


    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(_gravityForceDirection);
    }
}
