using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCover : MonoBehaviour
{
    public GameObject[] farCover;
    public GameObject farCoverPick;
    public int index;

    public float speed;

    void Start()
    {
        farCover = GameObject.FindGameObjectsWithTag("FarCover");
        index = Random.Range(0, farCover.Length);
        farCoverPick = farCover[index];
    }

    void Update()
    {
        if (AIManager.inCover == false)
        {
            AIManager.agent.destination = farCoverPick.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AIManager.inCover = true;
    }
}
