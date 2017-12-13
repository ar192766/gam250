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
        rig.AddForce(transform.forward * bulletSpeed);
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(2);
        {
            Destroy(gameObject);
        }
    }

}
