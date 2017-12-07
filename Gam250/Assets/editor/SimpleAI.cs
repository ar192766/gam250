﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class SimpleAI : EditorWindow
{
    public bool wonder;
    public bool chasePlayer;
    public bool playerDection;
    public bool aiHealth;

    public static float amountOfHealth;
    
    public GameObject aiObject;
    public GameObject pathObject;

    [MenuItem("Tools/SimpleAI")]
	 public static void ShowAIWindow()
    {
        GetWindow<SimpleAI>("SimpleAI");
    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUILayout.Label("Simple AI", EditorStyles.boldLabel);

        aiObject = (GameObject)EditorGUILayout.ObjectField("AI Object", aiObject, typeof(Object), true);

        EditorGUILayout.LabelField("AI Behaviours Scripts", EditorStyles.boldLabel);

        wonder = EditorGUILayout.Toggle("Wonder", wonder);
        chasePlayer = EditorGUILayout.Toggle("Chase Player", chasePlayer);
        playerDection = EditorGUILayout.Toggle("Player Detection", playerDection);
        aiHealth = EditorGUILayout.Toggle("Health", aiHealth);

        if (aiHealth == true)
        {
            amountOfHealth = EditorGUILayout.FloatField("Amount of health", amountOfHealth);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Attach Behaviour Scripts"))
        {
            AddComponents();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Create AI"))
        {
            Instantiate(aiObject, new Vector3(0, 0, 0), Quaternion.identity);
        }

        EditorGUILayout.LabelField("AI Path", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Remember to add the 'Path' tag into the tag manager");

        EditorGUILayout.Space();

        pathObject = (GameObject)EditorGUILayout.ObjectField("AI Path Object", pathObject, typeof(object), true);
        pathObject.GetComponent<Collider>().enabled = true;
        pathObject.gameObject.tag = "Path";

        EditorGUILayout.Space();

        if (GUILayout.Button("Create Path Manually"))
        {
            Instantiate(pathObject, new Vector3(0, 0, 0), Quaternion.identity);
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Create Path With Mouse"))
        {
            Debug.Log("On");
        }
    }

    // Adds Navmeshagent, Rigidbody and scripts that have been selected
    void AddComponents()
    {
        Debug.Log(amountOfHealth);

        if (aiObject.GetComponent<PathManager>() == null)
        {
            aiObject.AddComponent<PathManager>();
        }

        if (wonder == true && aiObject.GetComponent<Wonder>() == null)
        {
            aiObject.AddComponent<Wonder>();
        }

        if (chasePlayer == true && aiObject.GetComponent<ChasePlayer>() == null)
        {
            aiObject.AddComponent<ChasePlayer>();
        }

        if (playerDection == true && aiObject.GetComponent<PlayerDetection>() == null)
        {
            aiObject.AddComponent<PlayerDetection>();
        }

        if (aiHealth == true && aiObject.GetComponent<Health>() == null)
        { 
            Health h = aiObject.AddComponent<Health>();
            h.health = amountOfHealth;
            Debug.Log("Health after attachment " + h.health.ToString());
        }

        if (aiObject.GetComponent<NavMeshAgent>() == null)
        {
            aiObject.AddComponent<NavMeshAgent>();
        }

        if (aiObject.GetComponent<Rigidbody>() == null)
        {
            aiObject.AddComponent<Rigidbody>();
        }
    }
}