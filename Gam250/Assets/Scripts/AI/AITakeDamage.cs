using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITakeDamage : MonoBehaviour
{
    Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            health.health -= 7f;
            Destroy(other.gameObject);
        }
    }
}
