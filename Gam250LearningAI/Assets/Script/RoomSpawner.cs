using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public GameObject plane;
    public GameObject spawnLocation;
    /*
      * public GameObject roomModel;
      * public GameObject roomPrefab;
      * public GameObject spawnLocation;
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Instantiate(plane, spawnLocation.transform.position, Quaternion.identity);
            /*
             * FarPosition.isFar = 0f;
             * MiddlePosition.isMiddle = 0f;
             * ClosePosition.isClose = 0f;
            */
        }
    }
}
