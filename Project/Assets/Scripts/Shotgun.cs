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

    public GameObject ShotgunReloadVFX;


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
            StartCoroutine(SpawnEffectAfterDelay(ShotgunReloadVFX, ExplosionPosition, 1.0f, 2.0f));
    }


    //TODO make a vfx manage class and put this inside.
    private IEnumerator SpawnEffectAfterDelay(GameObject effect, Transform position, float delay, float destroyDelay){
        yield return new WaitForSeconds(delay);
        GameObject vfx_effect = Instantiate(effect, ExplosionPosition);
        vfx_effect.GetComponent<ParticleSystem>().Play();
        Destroy(vfx_effect, destroyDelay);
    }
}
