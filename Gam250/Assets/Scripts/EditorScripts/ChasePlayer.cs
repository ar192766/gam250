using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent agent;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
	}
	
	
	void Update ()
    {
       

        if (PathManager.isChasingPlayer == true)
        {
            agent.destination = player.transform.position;
        }
	}
}
