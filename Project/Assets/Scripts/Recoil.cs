using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
    public float reloadTime = 0.0f;
    private Timer reloadTimer = new Timer();


    public void Start(){
    }

    void Update(){
        reloadTimer.Tick();

        if(Input.GetMouseButton(0) && reloadTimer.IsFinished()){
            playerModel.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPosition.position, explosionRadius);
            reloadTimer.Start(reloadTime);
            //No indicator of shooting so
            Debug.Log("Shot");
        }

        playerModel.transform.rotation = Quaternion.Euler(0, cameraFollowTarget.transform.rotation.eulerAngles.y, 0);
        Quaternion lookRotation = Quaternion.LookRotation((mainCamera.position + mainCamera.forward * 10.0f) - playerSpine.position);
        playerSpine.rotation = math.slerp(playerSpine.rotation, lookRotation, 1.0f);
    }

    
    void FixedUpdate()
    {
        /**
            Might be necessary for the rigidbody physics I just didn't want to put the timer ticker here 
            because it might cause some weird stuff to happen. This ticks at a solid 60 fps while update goes much faster.
        **/
    }
}
