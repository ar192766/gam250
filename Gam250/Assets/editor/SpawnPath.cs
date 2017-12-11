using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class SpawnPath : MonoBehaviour
{

    static SpawnPath()
    {
        SceneView.onSceneGUIDelegate += OnSceneGooey;
    }


    static void OnSceneGooey(SceneView sceneView)
    {
       /* Event e = Event.current;
        GameObject path;
        path = Resources.Load("SPAGETTI") as GameObject;
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (e.type == EventType.MouseDown && e.button == 0)
        {
            Debug.Log("Spawn");
            SimpleAI.pathObject = Instantiate(path,mousePos, Quaternion.identity) as GameObject;
        }
        */
    }
}
