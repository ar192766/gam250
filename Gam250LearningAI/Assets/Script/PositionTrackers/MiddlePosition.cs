using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePosition : MonoBehaviour
{
    public static bool isMiddle;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isMiddle = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isMiddle = false;
        }
    }
}
