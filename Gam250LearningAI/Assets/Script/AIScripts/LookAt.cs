using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject player;
	
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    void Update()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.LookAt(playerPosition);
    }
	
}
