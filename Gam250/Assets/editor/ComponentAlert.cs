using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ComponentAlert : EditorWindow
{
    static public void Tester()
    {
        ComponentAlert window = ScriptableObject.CreateInstance<ComponentAlert>();
        window.position = new Rect(Screen.width / 0.4f, Screen.height / 1.5f, 300, 200);
        window.ShowPopup();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Component Alert", EditorStyles.wordWrappedLabel);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("No Behaviours where added to the AI", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Would you like to add some Components");

        EditorGUILayout.Space();

        SimpleAI.wonder = EditorGUILayout.Toggle("Wonder", SimpleAI.wonder);

        if (SimpleAI.wonder == true)
        {
            SimpleAI.lookAround = EditorGUILayout.Toggle("Look Around", SimpleAI.lookAround);
        }

        SimpleAI.playerDection = EditorGUILayout.Toggle("Player Detection", SimpleAI.playerDection);
        if(SimpleAI.playerDection == true)
        {
            SimpleAI.chasePlayer = EditorGUILayout.Toggle("Chase Player", SimpleAI.chasePlayer);
        }

        SimpleAI.healthManager = EditorGUILayout.Toggle("Health Manager", SimpleAI.healthManager);

        if (SimpleAI.healthManager == true)
        {
            SimpleAI.amountOfHealth = EditorGUILayout.FloatField("Amount of health", SimpleAI.amountOfHealth);
        }

        if (GUILayout.Button("Add Components"))
        {
            SimpleAI.attachComponents = true;
            this.Close();

            if(SimpleAI.healthManager == true)
            {
                SimpleAI.createManager = new GameObject();
                SimpleAI.createManager.name = "HealthManager";
                HealthManager health = SimpleAI.createManager.AddComponent<HealthManager>();
                health.healthOverride = SimpleAI.amountOfHealth;
            }
        }
    }
}
  