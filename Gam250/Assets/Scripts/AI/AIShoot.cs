using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    PathManager pathManager;

    public GameObject bullet;
    public GameObject bulletSpawn;

    bool canShoot = true;

    void Start()
    {
        bullet = Resources.Load("AIBullet") as GameObject;
        pathManager = GetComponent<PathManager>();
    }

    void Update()
    {
        //Checks PathManager script to see if the ischasing is true if so start shooting
        if(pathManager.isChasing == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (canShoot == true)
            {
                //Spawns AIBullet prefab at the spawn location
                Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
                canShoot = false;
                StartCoroutine(WaitToShoot());
            }
    }

    //Makes the AI wait 2 seconds before it can shoot again
    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(2);
        canShoot = true;

    }
}