using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountOfAI : MonoBehaviour
{
    public GameObject[] ai;
    public int aiAmount;
    public Text aiAmountText;
	
	void Update ()
    {
        //Gets the amount of AI in the Level and displays it as a UI Text
        ai = GameObject.FindGameObjectsWithTag("AI");
        aiAmount = ai.Length;
        aiAmountText.text = aiAmount.ToString();
	}

}
