using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{   
    public Transform cameraFollowTarget;
    public Transform mainCamera;   
    public Transform playerModel;
    public Transform playerSpine;

    void Update(){
        playerModel.transform.rotation = Quaternion.Euler(0, cameraFollowTarget.transform.rotation.eulerAngles.y, 0);
        Quaternion lookRotation = Quaternion.LookRotation((mainCamera.position + mainCamera.forward * 10.0f) - playerSpine.position);
        playerSpine.rotation = math.slerp(playerSpine.rotation, lookRotation, 0.9f);
    }
}
