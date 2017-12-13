using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{

    public PathManager pathManager;

    public float range = 7;
    public float angle = 40;

    void Start()
    {
        pathManager = GetComponentInParent<PathManager>();
    }
    void Update()
    {
        HitPlayer();
    }
    void HitPlayer()
    {
        Vector3 playerPostion = transform.position;
        Vector3 forward = transform.forward;
        Collider[] cols = Physics.OverlapSphere(playerPostion, range);
        foreach (Collider col in cols)
        {
            if (col && col.gameObject.CompareTag("Player"))
            {
                Vector3 dir = col.transform.position - playerPostion;
                if (Vector3.Angle(dir, forward) <= angle / 2)
                {
                    pathManager.isChasing = true;
                    pathManager.isWond = false;
                    Debug.Log("In Angle");
                }
            }
        }
    }
}
