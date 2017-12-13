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
        ai = GameObject.FindGameObjectsWithTag("AI");
        aiAmount = ai.Length;
        aiAmountText.text = aiAmount.ToString();
	}

}
