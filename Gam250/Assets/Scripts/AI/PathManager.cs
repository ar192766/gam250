using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    

    public static bool iSWondering;
        public bool isWonder;   

    public static bool isChasingPlayer;
        public bool isChasing;

    void Start()
    {
   
    }

    void Update()
    {
        isChasingPlayer = isChasing;
        iSWondering = isWonder;
    }

}
