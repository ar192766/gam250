using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
    public GameObject bulletSpawn;

    void Start()
    {
        bullet = Resources.Load("Bullet") as GameObject;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
        }

    }
}
