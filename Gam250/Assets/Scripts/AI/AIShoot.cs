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
        if(pathManager.isChasing == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (canShoot == true)
            {
                Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
                canShoot = false;
                StartCoroutine(WaitToShoot());
            }
    }

    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(2);
        canShoot = true;

    }
}