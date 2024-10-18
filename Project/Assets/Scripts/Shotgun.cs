using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform ExplosionPosition;
    public Transform PlayerRigidbody;
    public int ExplosionForce = 0;
    public int ExplosionRadius = 0;
    public float ReloadTime = 0.0f;

    public AudioClip ShotgunShot;
    public AudioClip ShotgunReload;


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
            PlayerRigidbody.GetComponent<Rigidbody>().AddExplosionForce(ExplosionForce, ExplosionPosition.position, ExplosionRadius);
            _reloadTimer.Start(ReloadTime);
            SoundEffectManager.Instance.PlaySound(ShotgunShot, ExplosionPosition, 1.0f);
            SoundEffectManager.Instance.PlaySoundNoPitchDelayed(ShotgunReload, ExplosionPosition, 1.0f, 1.0f);
            //No indicator of shooting so
            Debug.Log("Shot");
    }
}
