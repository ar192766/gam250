using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public int lookChance = 10;
    public float timeToLook = 10f;

    public float angle = 360f;
    public float time = 1f;
    Vector3 axis = Vector3.up;

	void Start ()
    {
	}
	
	void Update ()
    {
        timeToLook -= 1f * Time.deltaTime;
        if(timeToLook < 0)
        {
            lookChance = Random.Range(0, 10);
            timeToLook = 10f;
        }

        if (lookChance < 3)
        {
            PathManager.iSWondering = false;
        }
	}

    void RotateAI()
    {

    }
}
