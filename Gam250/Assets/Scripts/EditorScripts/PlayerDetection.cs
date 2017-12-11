using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public float rayDistance;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        RaycastHit hit;

        var rayrotate = transform.rotation.eulerAngles;
        rayrotate.x = 0;
        rayrotate.z = 0;
        rayrotate.y = 0;

        Vector3 fwd = transform.TransformDirection(Vector3.forward * rayDistance);
        Debug.DrawRay(transform.position, fwd, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, rayDistance))
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
