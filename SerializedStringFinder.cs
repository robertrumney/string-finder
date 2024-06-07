using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class SerializedStringFinder : EditorWindow
{
    // The substring to search for
    private string searchString = "";
    // The string to replace the search string with
    private string replaceString = "";
    // List to hold the results
    private List<Result> results = new List<Result>();

    [MenuItem("Tools/Serialized String Finder")]
    public static void ShowWindow()
    {
        GetWindow<SerializedStringFinder>("Serialized String Finder");
    }

    private void OnGUI()
    {
        GUILayout.Label("Find and Replace Serialized Strings", EditorStyles.boldLabel);

        // Input field for the search string
        searchString = EditorGUILayout.TextField("Search String", searchString);

        // Input field for the replace string
        replaceString = EditorGUILayout.TextField("Replace String", replaceString);

        // Button to start the search
        if (GUILayout.Button("Find"))
        {
            FindSerializedStrings();
        }

        // Button to replace the found instances
        if (GUILayout.Button("Replace All"))
        {
            ReplaceSerializedStrings();
        }

        // Display the results
        if (results.Count > 0)
        {
            GUILayout.Label("Results:", EditorStyles.boldLabel);
            foreach (var result in results)
            {
                if (GUILayout.Button(result.Display))
                {
                    // Select the GameObject in the hierarchy
                    Selection.activeGameObject = result.GameObject;
                }
            }
        }
    }

    private void FindSerializedStrings()
    {
        // Clear previous results
        results.Clear();

        // Get all GameObjects in the scene
        var gameObjects = FindObjectsOfType<GameObject>();

        foreach (var go in gameObjects)
        {
            // Get all components on the GameObject
            var components = go.GetComponents<Component>();

            foreach (var component in components)
            {
                // Get all serialized fields of the component
                var serializedObject = new SerializedObject(component);
                var property = serializedObject.GetIterator();

                while (property.NextVisible(true))
                {
                    // Check if the property is a string and contains the search string
                    if (property.propertyType == SerializedPropertyType.String && property.stringValue.Contains(searchString))
                    {
                        results.Add(new Result
                        {
                            GameObject = go,
                            Component = component,
                            PropertyPath = property.propertyPath,
                            Display = $"{go.name} ({component.GetType().Name}) - {property.displayName}: {property.stringValue}"
                        });
                    }
                }
            }
        }

        // Refresh the window to show results
        Repaint();
    }

    private void ReplaceSerializedStrings()
    {
        foreach (var result in results)
        {
            // Get the serialized object and property
            var serializedObject = new SerializedObject(result.Component);
            var property = serializedObject.FindProperty(result.PropertyPath);

            // Replace the string value
            if (property != null && property.propertyType == SerializedPropertyType.String)
            {
                property.stringValue = property.stringValue.Replace(searchString, replaceString);
                serializedObject.ApplyModifiedProperties();
            }
        }

        // Refresh the results after replacement
        FindSerializedStrings();
    }

    private class Result
    {
        public GameObject GameObject;
        public Component Component;
        public string PropertyPath;
        public string Display;
    }
}
