using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wonder : MonoBehaviour
{
    NavMeshAgent agent;

    Rigidbody rig;
    public GameObject[] aiPaths;
    public GameObject currentPath;
    public int index;
    public int lastRandomNumber;
	
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();

        rig = GetComponent<Rigidbody>();
        aiPaths = GameObject.FindGameObjectsWithTag("Path");

        index = Random.Range(0, aiPaths.Length);
        currentPath = aiPaths[index];

        rig.useGravity = false;
        lastRandomNumber = index;
    }

	void Update ()
    {
        if (PathManager.iSWondering == true)
        {
            agent.destination = currentPath.transform.position;
        }

        if (index == lastRandomNumber)
        {
            index = Random.Range(0, aiPaths.Length);
            currentPath = aiPaths[index];
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OK");

        if (other.tag == "Path")
        {
            Debug.Log("Path Hit");
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
