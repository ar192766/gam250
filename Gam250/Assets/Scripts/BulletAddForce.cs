using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAddForce : MonoBehaviour
{
    Health health;
    Shoot shoot;
    Rigidbody rig;
    public float bulletSpeed;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Makes the bullet move the direction the player is facing
        rig.AddForce(transform.forward * bulletSpeed);
    }

    IEnumerator WaitToDestroy()
    {
        //Waits 2 seconds  then destroys itself
        yield return new WaitForSeconds(2);
        {
            Destroy(gameObject);
        }
    }

}
