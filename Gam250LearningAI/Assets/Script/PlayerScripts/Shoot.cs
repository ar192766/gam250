using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject bullet;
	
	void Start ()
    {
        bullet = Resources.Load("Bullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
    { 

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bullet = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity) as GameObject;
        }
	}

}
