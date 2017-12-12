using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surrender : MonoBehaviour
{
    PathManager pathManager;

    NavMeshHandler navHandler;

    Health getHealth;
    public int surrenderChance;
    public bool surrenderCheck;
	
	void Start ()
    {
        pathManager = GetComponent<PathManager>();

        navHandler = GetComponent<NavMeshHandler>();
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
                pathManager.isWond = false;
                pathManager.isChasing = false;

                navHandler.agent.destination = transform.position;
            }
        }
	}
}
