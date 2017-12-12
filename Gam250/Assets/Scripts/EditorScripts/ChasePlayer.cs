using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    PathManager pathManager;
    NavMeshHandler navHandler;

    public GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navHandler = GetComponent<NavMeshHandler>();
        pathManager = GetComponent<PathManager>();
	}
	
	
	void Update ()
    {
        if (pathManager.isChasing == true)
        {
            navHandler.agent.destination = player.transform.position;
        }
	}
}
