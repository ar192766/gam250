using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    PathManager pathManager;
    NavMeshHandler navHandler;

    public int lookChance = 10;
    public float timeToLook = 40f;
    

    public bool canLook = true;
    public float turnSpeed = 70;
    public float timeToWonder = 5f;

	void Start ()
    {
        navHandler = GetComponent<NavMeshHandler>();
        pathManager = GetComponent<PathManager>();
	}
	
	void Update ()
    {
        LookChance();

        if (timeToWonder < 0)
        {
            lookChance = 10;
            timeToWonder = 5f;
            navHandler.agent.speed = 3.5f;
        }
	}

    void LookChance()
    {
        if (pathManager.isChasing == true)
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
                navHandler.agent.speed = 0;
                navHandler.agent.destination = transform.position;
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

                timeToWonder -= 1f * Time.deltaTime;
            }
        }

    }
}
