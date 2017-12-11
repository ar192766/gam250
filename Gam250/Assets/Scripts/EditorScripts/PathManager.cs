using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static bool iSWondering;
    public bool isWond;
    public bool isChasing;

    public static bool isChasingPlayer;

    void Start()
    {
        iSWondering = true;
    }

    void Update()
    {
        isChasing = isChasingPlayer;
        isWond = iSWondering;
    }

}
