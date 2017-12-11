using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAround : MonoBehaviour
{
    NavMeshAgent agent;

    public int lookChance = 10;
    public float timeToLook = 40f;

    public bool canLook = true;
    public float turnSpeed = 70;
    public float timeToWonder = 5f;

	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        LookChance();

        if (timeToWonder < 0)
        {
            lookChance = 10;
            timeToWonder = 5f;
            agent.speed = 3.5f;
        }
	}

    void LookChance()
    {
        if (PathManager.isChasingPlayer == true)
        {
            Debug.Log("AI is chasing player");
        }
        else
        {
            timeToLook -= 1f * Time.deltaTime;
            if (timeToLook < 0)
            {
                lookChance = Random.Range(0, 10);
                timeToLook = 40f;
            }

            if (lookChance < 3 && canLook == true)
            {
                agent.speed = 0;
                agent.destination = transform.position;
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

                timeToWonder -= 1f * Time.deltaTime;
            }
        }

    }
}
