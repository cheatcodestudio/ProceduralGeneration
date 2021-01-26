using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpecialBlock : MonoBehaviour
{
    public List<SpecialSpawner> rayCastingPositions;
    public static Action ClearObjects = delegate { };

    public void Generate()
    {
        foreach(SpecialSpawner item in rayCastingPositions)
        {
            if (!Physics.Raycast(item.rayCastOrigin.position, -Vector3.up, 10))
                item.SpawnPrefab();
        }
    }
    public void Create()
    {
        ClearObjects();
        Generate();
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(SpecialBlock))]
public class SpecialBlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var t = (target as SpecialBlock);

        base.OnInspectorGUI();
        if (GUILayout.Button("Generate"))
            t.Create();
    }
}
#endif