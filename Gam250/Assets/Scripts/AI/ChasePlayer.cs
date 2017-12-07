using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public GameObject player;
 

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update ()
    {
       

        if (PathManager.isChasingPlayer == true)
        {
            PathManager.agent.destination = player.transform.position;
        }
	}
}
