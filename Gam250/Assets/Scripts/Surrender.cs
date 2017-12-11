using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Surrender : MonoBehaviour
{
    NavMeshAgent agent;

    Health getHealth;
    public int surrenderChance;
    public bool surrenderCheck;
	
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        getHealth = GetComponent<Health>();
	}
	
	
	void Update ()
    {
        if (getHealth.health < 10 && surrenderCheck == false)
        {
            surrenderChance = Random.Range(0, 10);
            surrenderCheck = true;
            if (surrenderChance < 3)
            {
                Debug.Log("Surrender");
                PathManager.iSWondering = false;
                PathManager.isChasingPlayer = false;

                agent.destination = transform.position;
            }
        }
	}
}
