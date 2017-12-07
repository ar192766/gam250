using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTimer: MonoBehaviour
{
    public float farTimer;
    public float middleTimer;
    public float closeTimer;

    void Update ()
    {
        TimePlayerPosition();
        FindHighestTime();
    }

    void TimePlayerPosition()
    {
        if (FarPosition.isFar == true)
        {
            farTimer += 1 * Time.deltaTime;
        }

        if (MiddlePosition.isMiddle == true)
        {
            middleTimer += 1 * Time.deltaTime;
        }

        if (ClosePosition.isClose == true)
        {
            closeTimer += 1 * Time.deltaTime;
        }
    }

    void FindHighestTime()
    {
       //Sort Between times to find the highest time
    }
}
