using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : BasicEnemy
{
    public GameObject bullet;
    public float attackSpeed = 1.5f;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other); // Inherit base behavior if needed

        if (other.name == "EnemyShootCollider")
        {
            _agent.speed = 0;
            _agent.velocity = Vector3.zero;
            InvokeRepeating("Shoot", 0.5f, attackSpeed);
        }
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other); // Reset base behavior

        CancelInvoke("Shoot");
    }

    public void Shoot()
    {
        transform.LookAt(player.transform);
        GameObject shootBullet = Instantiate(bullet, new Vector3(0, 0.5f, 0.7f), Quaternion.Euler(0, -90, 0));
        shootBullet.transform.SetParent(this.transform, false);
        shootBullet.GetComponent<Rigidbody>().velocity = transform.forward * 25f;
        Destroy(shootBullet, 3f);
    }
}
