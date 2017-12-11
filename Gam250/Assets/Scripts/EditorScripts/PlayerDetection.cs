using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float rayDistance;
    Vector3 center;
    float radius;

	void Update ()
    {
        Quaternion rotationRight = Quaternion.AngleAxis(30, transform.up);
        Quaternion rotationLeft = Quaternion.AngleAxis(-30, transform.up);
        

        Vector3 rayR = rotationRight * transform.forward * rayDistance;
        Vector3 rayL = rotationLeft * transform.forward * rayDistance;

        Debug.DrawRay(transform.position, rayR, Color.red);
        Debug.DrawRay(transform.position, rayL, Color.red);
 

        RaycastHit hit;

        if (Physics.Raycast(transform.position, rayR, out hit, rayDistance) ||(Physics.Raycast(transform.position, rayL, out hit, rayDistance)))
        {
            if (hit.collider.tag == "Player")
            {
                PathManager.iSWondering = false;
                PathManager.isChasingPlayer = true;
                Debug.Log("Player Hit");
            }
        }
    }
}
