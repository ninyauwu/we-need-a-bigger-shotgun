using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent agent;
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.transform.position);
    }
}
