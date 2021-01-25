using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTempleRun : MonoBehaviour
{
    public float speed = 3;
    public GameObject prefab;
    public Vector3 startPoint;
    public float offset;
    
    private void FixedUpdate()
    {
        transform.localPosition += Vector3.forward * Time.deltaTime * speed;
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        SpawnNewBlock();
    }
    private void SpawnNewBlock()
    {
        Instantiate(prefab, startPoint, Quaternion.identity);
        startPoint.z += offset;
    }
}
