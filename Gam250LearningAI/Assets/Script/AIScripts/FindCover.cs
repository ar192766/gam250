using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using BehaviourMachine;

public class FindCover : StateBehaviour
{
    public static NavMeshAgent agent;
    public GameObject[] farCover;
    public GameObject farCoverPick;
    public int index;

    public float speed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        farCover = GameObject.FindGameObjectsWithTag("FarCover");

        index = Random.Range(0, farCover.Length);
        farCoverPick = farCover[index];
    }

    void Update()
    {
        agent.destination = farCoverPick.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
