using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wonder : MonoBehaviour
{
    PathManager pathManager;
    NavMeshHandler navHandler;

    Rigidbody rig;
    public GameObject[] aiPaths;
    public GameObject currentPath;
    public int index;
    public int lastRandomNumber;
	
	void Start ()
    {
        pathManager = GetComponent<PathManager>();

        navHandler = GetComponent<NavMeshHandler>();

        rig = GetComponent<Rigidbody>();
        aiPaths = GameObject.FindGameObjectsWithTag("Path");

        index = Random.Range(0, aiPaths.Length);
        currentPath = aiPaths[index];

        rig.useGravity = false;
        lastRandomNumber = index;
    }

	void Update ()
    {
        if (pathManager.isWond == true)
        {
            navHandler.agent.destination = currentPath.transform.position;
        }

        if (index == lastRandomNumber)
        {
            index = Random.Range(0, aiPaths.Length);
            currentPath = aiPaths[index];
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Path")
        {
            lastRandomNumber = index;
            RandomDestination();
        }
    }

    void RandomDestination()
    {
        if (index == lastRandomNumber)
        {
            index = Random.Range(0, aiPaths.Length);
            currentPath = aiPaths[index];
        }
    }
}
