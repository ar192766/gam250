using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshHandler : MonoBehaviour
{
    public NavMeshAgent agent;
	
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	

}
