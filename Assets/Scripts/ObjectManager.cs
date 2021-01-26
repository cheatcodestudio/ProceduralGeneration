using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> spawnedObjects;

    private void OnEnable()
    {
        SpecialSpawner.AddObjects += AddObjects;
        SpecialBlock.ClearObjects += ClearObjects;
    }
    private void OnDisable()
    {
        SpecialSpawner.AddObjects -= AddObjects;
        SpecialBlock.ClearObjects -= ClearObjects;
    }
    private void AddObjects(GameObject go)
    {
        spawnedObjects.Add(go);
    }
    private void ClearObjects()
    {
        for(int x= 0; x < spawnedObjects.Count;x++)
        {
            DestroyImmediate(spawnedObjects[x]);
        }
        spawnedObjects.Clear(); 
    }
}
