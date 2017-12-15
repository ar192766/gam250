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
        //Finds and gets component off of HealtManager Gameobject
        healthManager = GameObject.FindGameObjectWithTag("HealthManager").GetComponent<HealthManager>();
    }

	void Update ()
    {
        //Keeps track of how many AI die
		if(aiIsDead == true)
        {
            deadAmount += 1;
            aiIsDead = false;
        }

        AIadapt();
	}
    
    //This Function switches when the dead amount int = 2,4,6 or 8
    void AIadapt()
    {
        //Inside each case a float randomly picks a number. whatever number it hits will give the AI an upgrade either by health or by Damage
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

    //Function Check to see what stage the Heath bonus is to the AI is then gives the AI more health
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

    //Function Check to see what stage the damage bonus is to the AI is then give the AI bullet more damage
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
