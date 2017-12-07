using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rig;
    public float bulletSpeed;
    Vector3 position;

	
	void Start ()
    {
        rig = GetComponent<Rigidbody>();
	}
	
	
	void Update ()
    {
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rig.AddForce(transform.forward  * bulletSpeed);
	}
}
