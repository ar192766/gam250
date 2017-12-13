using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor;

public class SimpleAI : EditorWindow
{
    public static bool wonder;
    public static bool lookAround;
    public static bool chasePlayer;
    public static bool playerDection;
    public static bool healthManager;

    public static bool attachComponents;

    public static float amountOfHealth;
    
    public GameObject aiObject;
    public  static GameObject pathObject;
    public static GameObject createManager;

    [MenuItem("Tools/SimpleAI")]
	public static void ShowAIWindow()
    {
        GetWindow<SimpleAI>("SimpleAI");
    }

    void Update()
    {
        if (attachComponents == true)
        {
            AddComponents();
            attachComponents = false;
        }
    }

    void OnGUI()
    {
        GUILayout.Label("Simple AI", EditorStyles.boldLabel);

        aiObject = (GameObject)EditorGUILayout.ObjectField("AI Object", aiObject, typeof(Object), true);

        EditorGUILayout.LabelField("AI Behaviours Scripts", EditorStyles.boldLabel);

        wonder = EditorGUILayout.Toggle("Wonder", wonder);

        if (wonder == true)
        {
            lookAround = EditorGUILayout.Toggle("Look Around", lookAround);
        }

        playerDection = EditorGUILayout.Toggle("Player Detection", playerDection);
        if(playerDection == true)
        {
            chasePlayer = EditorGUILayout.Toggle("Chase Player", chasePlayer);
        }

        healthManager = EditorGUILayout.Toggle("Health Manager", healthManager);

            if (healthManager == true)
            {
            EditorGUILayout.LabelField("Remember to add the 'HealthManager' tag into the tag manager");
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
            aiObject.name = "AI";

                createManager = new GameObject();
                SimpleAI.createManager.name = "HealthManager";
                HealthManager health = createManager.AddComponent<HealthManager>();
                health.healthOverride = amountOfHealth;
                Debug.Log("Health after attachment " + health.healthOverride.ToString());
            }

        EditorGUILayout.LabelField("AI Path", EditorStyles.boldLabel);
        EditorGUILayout.LabelField("Remember to add the 'Path' tag into the tag manager");

        EditorGUILayout.Space();

        pathObject = (GameObject)EditorGUILayout.ObjectField("AI Path Object", pathObject, typeof(object), true);

            if (pathObject != null)
            {
                pathObject.GetComponent<Collider>().enabled = true;
                pathObject.gameObject.tag = "Path";
            }

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

        if (wonder == false & chasePlayer == false && playerDection == false && healthManager == false && attachComponents == false)
        {
            ComponentAlert.Tester();
        }

        if (aiObject.GetComponent<PathManager>() == null)
        {
            aiObject.AddComponent<PathManager>();
        }

        if (wonder == true && aiObject.GetComponent<Wonder>() == null)
        {
            aiObject.AddComponent<Wonder>();
        }

        if (lookAround == true && aiObject.GetComponent<LookAround>() == null)
        {
            aiObject.AddComponent<LookAround>();
        }

        if (chasePlayer == true && aiObject.GetComponent<ChasePlayer>() == null)
        {
            aiObject.AddComponent<ChasePlayer>();
        }

        if (playerDection == true && aiObject.GetComponent<PlayerDetection>() == null)
        {
            aiObject.AddComponent<PlayerDetection>();
        }

        if (healthManager == true && aiObject.GetComponent<Health>() == null)
        {
            aiObject.AddComponent<Health>(); 
        }

        if (aiObject.GetComponent<NavMeshAgent>() == null)
        {
            aiObject.AddComponent<NavMeshAgent>();
        }

        if (aiObject.GetComponent<Rigidbody>() == null)
        {
            aiObject.AddComponent<Rigidbody>();
        }

        if (aiObject.GetComponent<NavMeshHandler>() == null)
        {
            aiObject.AddComponent<NavMeshHandler>();
        }
    }
}
