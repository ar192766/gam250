using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject bulletPrefab;

    public float bulletSpeed;
    public int ammo = 30;


	void Start ()
    {
        bulletPrefab = Resources.Load("Bullet") as GameObject;
	}
	
	// Update is called once per frame
	void Update ()
    { 

        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
        {
            GameObject bulletPrefab = Instatiate(Bullet) as GameObject;
            bulletPrefab.transform.position = bulletSpawn.transform.position + Camera.main.transform.forward * 0.5f;

            Rigidbody rig = bulletPrefab.GetComponent<Rigidbody>();
            rig.velocity = Camera.main.transform.forward * bulletSpeed;

            ammo -= 1;
        }
	}

}
