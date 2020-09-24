using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class SimpleEditor : EditorWindow
{
    VisualElement root;
    List<GameObject> _go = new List<GameObject>(); 

    [MenuItem("Tool/Beispiel")]
    public static void ShowWindow()
    {
        var window = GetWindow<SimpleEditor>();

        window.titleContent =new GUIContent("Simple Editor");
        window.minSize = new Vector2(150f, 50f);
    }

    private void OnEnable()
    {
        root = rootVisualElement;
        AddButtonsToGui();   
    }

    void AddButtonsToGui()
    {
        //VisualElement root = rootVisualElement;
        var button = new Button() { text = "Create Cube" };

        button.clicked += AddCube;
        button.style.width = 150f;
        button.style.height = 25f;

        root.Add(button);


        button = new Button() { text = "Destroy Cube" };

        button.clicked += DestroyCube;
        button.style.width = 150f;
        button.style.height = 25f;

        root.Add(button);
    }

    void AddCube()
    {
        var Go = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Go.transform.position = new Vector3(5, 0, 0);        
        _go.Add(Go);
    }

    void DestroyCube()
    {
        foreach (var item in _go)
        {
            DestroyImmediate(item);
        }
    }

}
