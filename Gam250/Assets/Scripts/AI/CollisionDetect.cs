using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    NavMeshHandler navHandler;
    Rigidbody rig;

    public float radius = 2;
    public bool frontBlocked;
    public bool rightBlocked;
    public bool leftBlocked;

    public float speed = 3;
    public float pickDirection;
	
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
        navHandler = GetComponent<NavMeshHandler>();
	}
	
	
	void FixedUpdate ()
    {
        RaycastHit hit;

        Vector3 forward = transform.forward * radius;
        Vector3 right = transform.right * radius;
        Vector3 left = -transform.right * radius;

        Debug.DrawRay(transform.position, forward, Color.red);
        Debug.DrawRay(transform.position, right, Color.red);
        Debug.DrawRay(transform.position, left, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out hit, radius))
        {
            if(hit.collider.tag == "Wall")
            {
                Debug.Log("Wall");
                frontBlocked = true;
            }
            else
            {
                frontBlocked = false;
                rightBlocked = false;
                leftBlocked = false;
            }
        }

        if(Physics.Raycast(transform.position, transform.right, out hit, radius))
        {
            if(hit.collider.tag == "Wall")
            {
                rightBlocked = true;
            }
        }

        if(Physics.Raycast(transform.position, -transform.position, out hit, radius))
        {
            if(hit.collider.tag == "Wall")
            {
                leftBlocked = true;
            }
        }

        if(frontBlocked == true)
        {
            pickDirection = Random.Range(1, 2);
            if(pickDirection == 1)
            {
                TurnRight();
            }
            else if(pickDirection == 2)
            {
                TurnLeft();
            }
        }
        else if(frontBlocked == false)
        {
            navHandler.agent.speed = 3.5f;
        }

        if(frontBlocked == true && rightBlocked == true)
        {
            TurnLeft();
        }
        else if(frontBlocked == true && leftBlocked == true)
        {
            TurnRight();
        }
	}

    void TurnRight()
    {
        if (frontBlocked == true)
        {
            navHandler.agent.speed = 0;

            rig.AddForce(transform.right * speed);
        }
    }

    void TurnLeft()
    {
        if (frontBlocked == true)
        {
            navHandler.agent.speed = 0;

            rig.AddForce(-transform.right * speed);
        }
    }
}
