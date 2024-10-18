using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BasicEnemy
{
    public GameObject Bullet;
    public float AttackSpeed = 1.5f;

    protected override void OnTriggerEnter(Collider other)
    {
        PlayerController playerController;
        if (other.TryGetComponent<PlayerController>(out playerController))
        {
            _agent.speed = 0;
            _agent.velocity = Vector3.zero;
            InvokeRepeating("Shoot", 0.01f, AttackSpeed);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        PlayerController playerController;
        if (other.TryGetComponent<PlayerController>(out playerController))
        {
            base.OnTriggerExit(other); // Reset base behavior
        CancelInvoke("Shoot");

        }

    }

    /// <summary>
    /// Shoots a bullet towards the player.
    /// </summary>
    private void Shoot()
    {
        transform.LookAt(Player.transform);
        GameObject shootBullet = Instantiate(Bullet, new Vector3(0, 0.5f, 0.7f), Quaternion.Euler(0, -90, 0));
        shootBullet.transform.SetParent(this.transform, false);
        shootBullet.GetComponent<Rigidbody>().velocity = transform.forward * 25f;
        Destroy(shootBullet, 3f);
    }
}
