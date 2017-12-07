using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathManager : MonoBehaviour
{
    public static NavMeshAgent agent;

    public static bool iSWondering;
        public bool isWonder;   

    public static bool isChasingPlayer;
        public bool isChasing;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        isChasingPlayer = isChasing;
        iSWondering = isWonder;
    }

}
