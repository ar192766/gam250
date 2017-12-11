using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISight : MonoBehaviour
{
    public bool PlayerInRange;
    public float rayLength;
    public GameObject player;
    public Vector3 playerPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (PlayerInRange == true)
        {
            Vector3 aiToPlayerRay = player.transform.position - transform.position;
            Debug.DrawRay(transform.position, aiToPlayerRay, Color.red);
            RaycastHit hit;

            if (Physics.Raycast(transform.position, aiToPlayerRay, out hit, rayLength))
            {
                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInRange = true;
            Debug.Log("In");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInRange = false;
            Debug.Log("Out");
        }
    }
}