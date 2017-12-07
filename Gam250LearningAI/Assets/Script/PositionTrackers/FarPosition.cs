using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarPosition : MonoBehaviour
{
    public static bool isFar;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isFar = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isFar = false;
        }
    }
}