using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public Transform rayCastOrigin;
    public Vector3 offset;

    public static Action<GameObject> AddObjects = delegate { };
    public void SpawnPrefab()
    {
        GameObject go;
         go = Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count)], transform.position + offset, Quaternion.identity);

        AddObjects(go);

        if (go.GetComponent<SpecialBlock>())
            go.GetComponent<SpecialBlock>().Generate();
    }
}
