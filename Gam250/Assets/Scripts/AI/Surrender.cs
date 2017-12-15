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
        //Checks if health of the AI is less than 10
        if (getHealth.health < 10 && surrenderCheck == false)
        {
            //Picks a random number and if that number is below 3 then the AI will stop e.g surrender
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
