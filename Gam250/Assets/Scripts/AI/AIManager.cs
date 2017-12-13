using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    HealthManager healthManager;

    public static bool aiIsDead;
    public int deadAmount;

    public int adaptAI;

    public int increaseDamage;
    public int increaseHealth;
    public int increaseSpeed;

    public bool oneLoop = true;

    void Start ()
    {
        healthManager = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<HealthManager>();
    }

	void Update ()
    {
		if(aiIsDead == true)
        {
            deadAmount += 1;
            aiIsDead = false;
        }

        AIadapt();
	}

    void AIadapt()
    {
        switch(deadAmount)
        {
            case 2:
                Debug.Log("2 dead");
                adaptAI = Random.Range(0, 7);

                if(adaptAI < 3 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseHealth += 1;
                    IncreaseHealth();
                }

                if(adaptAI > 3 & adaptAI < 6 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseDamage += 1;
                    IncreaseDamage();
                }
                
                break;

            case 4:
                adaptAI = Random.Range(0, 10);

                if (adaptAI < 3 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseHealth += 1;
                    IncreaseHealth();
                }

                if (adaptAI > 3 & adaptAI < 6 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseDamage += 1;
                    IncreaseDamage();
                }

                break;

            case 6:
                adaptAI = Random.Range(0, 10);

                if (adaptAI < 3 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseHealth += 1;
                    IncreaseHealth();
                }

                if (adaptAI > 3 & adaptAI < 6 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseDamage += 1;
                    IncreaseDamage();
                }

                break;
      
            case 8:
                adaptAI = Random.Range(0, 10);

                if (adaptAI < 3 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseHealth += 1;
                    IncreaseHealth();
                }

                if (adaptAI > 3 & adaptAI < 6 && oneLoop == true)
                {
                    oneLoop = false;
                    increaseDamage += 1;
                    IncreaseDamage();
                }

                break;
        }
    }

    void IncreaseHealth()
    {
        if(increaseHealth == 1)
        {
            healthManager.healthOverride += 15;
        }
        else if(increaseHealth == 2)
        {
            healthManager.healthOverride += 30;
        }
        else if(increaseHealth == 3)
        {
            healthManager.healthOverride += 45;
        }
    }

    void IncreaseDamage()
    {
        if(increaseDamage == 1)
        {
            playerMovement.bulletDamage = 10;
        }
        else if (increaseDamage == 2)
        {
            playerMovement.bulletDamage = 12;
        }
        else if (increaseDamage == 3)
        {
            playerMovement.bulletDamage = 14;
        }
    }
}
