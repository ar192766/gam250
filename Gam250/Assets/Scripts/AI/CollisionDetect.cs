using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    // Script Does not currently work. could get the AI to move becuase it was kinematic.

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

        //Making Vector3 for each 3 directions
        Vector3 forward = transform.forward * radius;
        Vector3 right = transform.right * radius;
        Vector3 left = -transform.right * radius;

        //Drawing the ray for each 3 directions
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

        //if only the front is blocked a float will pick a random number to determine what direction left or right it will go 
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

        //if front and right are blocked the AI will move left and if front and left is blocked then the AI wil move right
        if(frontBlocked == true && rightBlocked == true)
        {
            TurnLeft();
        }
        else if(frontBlocked == true && leftBlocked == true)
        {
            TurnRight();
        }
	}

    //makes AI move right in the game world
    void TurnRight()
    {
        if (frontBlocked == true)
        {
            navHandler.agent.speed = 0;

            rig.AddForce(transform.right * speed);
        }
    }
    //Makes AI move Left in the game world
    void TurnLeft()
    {
        if (frontBlocked == true)
        {
            navHandler.agent.speed = 0;

            rig.AddForce(-transform.right * speed);
        }
    }
}
