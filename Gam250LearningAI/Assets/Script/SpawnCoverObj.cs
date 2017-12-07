using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoverObj : MonoBehaviour
{
    public Cordinates cordinates;

    GameObject coverObj;

    public GameObject middleTimerObj;
    Vector3 middlePosition;

	void Start ()
    {
        coverObj = Resources.Load("CoverObj") as GameObject;
        middlePosition = new Vector3(Random.Range(coverObj.transform.position.x,coverObj.transform.position.x), 0.5f, Random.Range(coverObj.transform.position.z, coverObj.transform.position.z));

        coverObj = Instantiate(coverObj, middlePosition, Quaternion.identity);
    }
	
	void Update ()
    {
        //test = coverObj.transform.position.y;
	}
}

[System.Serializable]
public class Cordinates
{
    public float[] FarCordinates;

    public float MiddleCordinates;

    public float CloseCordinates;

}