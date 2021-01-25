using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    public Transform rayCastOrigin;
    public Vector3 offset;
    
    public void SpawnPrefab()
    {
        GameObject go;
         go = Instantiate(prefabs[Random.Range(0, prefabs.Count)], transform.position + offset, Quaternion.identity);

        if (go.GetComponent<SpecialBlock>())
            go.GetComponent<SpecialBlock>().Generate();
    }
}
