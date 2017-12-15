using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITakeDamage : MonoBehaviour
{
    Health health;

    private void Start()
    {
        //Gets Health script from the AI
        health = GetComponent<Health>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Checks the tag for Bullet if true then the AI's health will be reduced
        if (other.tag == "Bullet")
        {
            health.health -= 7f;
            Destroy(other.gameObject);
        }
    }
}
