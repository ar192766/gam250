using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    HealthManager healthManager;
    public float health;

    private void Start()
    {
        healthManager = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<HealthManager>();
    }

    void Update()
    {
        health = healthManager.healthOverride;

        if(health < 0)
        {
            AIManager.aiIsDead = true;
            Destroy(gameObject);
        }
    }
}
