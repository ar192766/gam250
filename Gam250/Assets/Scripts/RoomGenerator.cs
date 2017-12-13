using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public GameObject room;
    public GameObject roomComplete;
    public GameObject roomSpawnPoint;

    void Start ()
    {
        room = Resources.Load("Room") as GameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            roomComplete = Instantiate(room, roomSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
