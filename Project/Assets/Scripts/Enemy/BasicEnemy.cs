using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public GameObject player;
    protected NavMeshAgent _agent;

    public int health;
    public float speed;
    private float _speedSave;
    public float acceleration;

    protected virtual void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = speed;
        _agent.acceleration = acceleration;
        _speedSave = speed;
    }

    protected virtual void Update()
    {
        MoveToPlayer();
    }

    protected void MoveToPlayer()
    {
        _agent.SetDestination(player.transform.position);
    }

    public virtual void Death()
    {
        // Implement enemy death behavior (generic)
        Debug.Log("Enemy died");
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // Generic enemy trigger behavior (can be extended by derived classes)
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        // Reset speed or other behaviors
        _agent.speed = _speedSave;
    }
}
