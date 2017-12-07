using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static NavMeshAgent agent;

    public static bool inCover;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

    }
}
