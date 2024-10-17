using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody Rigidbody;
    public GameObject CameraFollowTarget;
    public void OnAttack(InputValue value)
    {
        // Set the rigidbody velocity opposite the camera directions
        Rigidbody.velocity -= CameraFollowTarget.transform.forward * 3.0F;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!TryGetComponent(out Rigidbody))
        {
            throw new NullReferenceException("PlayerController did not find Rigidbody component.");
        }
        if (CameraFollowTarget == null)
        {
            throw new NullReferenceException("PlayerController does not have CameraFollowTarget set.");
        }
    }
}
