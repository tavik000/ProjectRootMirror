using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileGenerator))]

public class TileGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate"))
        {
            TileGenerator manager = (TileGenerator) target;
            manager.Generate();
        }
        
        if (GUILayout.Button("DestroyAllChild"))
        {
            TileGenerator manager = (TileGenerator) target;
            manager.DestroyAllChild();
        }
    }
}
