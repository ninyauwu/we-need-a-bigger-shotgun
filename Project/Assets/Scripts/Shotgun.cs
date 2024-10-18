using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform explosionPosition;
    public Transform playerRigidbody;
    public int explosionForce = 0;
    public int explosionRadius = 0;
    public float reloadTime = 0.0f;

    public AudioClip shotgunShot;
    public AudioClip shotgunReload;


    private Timer _reloadTimer = new Timer();

    void Update(){
        _reloadTimer.Tick();

        if(Input.GetMouseButton(0) && _reloadTimer.IsFinished()){
            Shoot();
        }
    }

    
    void FixedUpdate()
    {
        /**
            Might be necessary for the rigidbody physics I just didn't want to put the timer ticker here 
            because it might cause some weird stuff to happen. This ticks at a solid 60 fps while update goes much faster.
        **/
    }

    private void Shoot(){
            playerRigidbody.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, explosionPosition.position, explosionRadius);
            _reloadTimer.Start(reloadTime);
            //No indicator of shooting so
            SoundEffectManager.Instance.PlaySound(shotgunShot, explosionPosition, 1.0f);
            SoundEffectManager.Instance.PlaySoundNoPitchDelayed(shotgunReload, explosionPosition, 1.0f, 1.0f);
            Debug.Log("Shot");
    }
}
