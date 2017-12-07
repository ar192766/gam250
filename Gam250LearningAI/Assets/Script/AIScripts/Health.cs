using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

public class Health : StateBehaviour
{
    public static float health = 50;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collder other)
    {
        if (other.tag == "Bullet")
        {
            health -= 5f;
            Dead();
        }
    }

    void Dead()
    {
        if(health == 0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HealthPack")
        {
            health == 50f;
        }
    }
}
