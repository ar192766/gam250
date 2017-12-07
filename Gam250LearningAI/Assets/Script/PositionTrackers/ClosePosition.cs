using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePosition : MonoBehaviour
{
    public static bool isClose;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isClose = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isClose = false;
        }
    }
}
