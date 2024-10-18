using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent _agent;

    public int health;
    public float speed;
    private float _speedSave;
    public float acceleration;
    public float attackSpeed;

    public GameObject bullet;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        _agent.acceleration = acceleration;
        _speedSave = speed;
  
    }


    void Update()
    {
        _agent.SetDestination(player.transform.position);
    }


    public void Shoot()
    {
        transform.LookAt(player.transform);
        GameObject shootBullet = Instantiate(bullet, new Vector3(0, 0.5f, 0.7f), Quaternion.Euler(0, -90, 0));
        shootBullet.transform.SetParent(this.transform, false);


        shootBullet.GetComponent<Rigidbody>().velocity = transform.forward * 20f;


        Destroy(shootBullet, 3f);



    }

    public void Death()
    {

    }


 
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        if (other.name == "EnemyShootCollider")
        {
            Debug.Log("enter2");
            _agent.speed = 0;
            _agent.velocity = Vector3.zero;
            InvokeRepeating("Shoot", 0.5f, 1.5f);


        }
    }

    private void OnTriggerExit(Collider other)
    {
        _agent.speed = _speedSave;
        CancelInvoke("Shoot");
    }

}
