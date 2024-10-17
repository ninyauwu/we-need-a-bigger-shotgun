using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Transform explosionPosition;
    public Transform playerModel;
    public Transform cameraFollowTarget;
    public Transform mainCamera;
    public Transform playerSpine;
    public int explosionForce = 0;
    public int explosionRadius = 0;



    void Update(){
        playerModel.transform.rotation = Quaternion.Euler(0, cameraFollowTarget.transform.rotation.eulerAngles.y, 0);
        Quaternion lookRotation = Quaternion.LookRotation((mainCamera.position + mainCamera.forward * 10.0f) - playerSpine.position);
        playerSpine.rotation = lookRotation;
    }

    
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0)){
            playerModel.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPosition.position, explosionRadius);
        }
    }
}
