using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTempeRun : MonoBehaviour
{
    public float speed = 3;
    public List<GameObject> prefab;
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
        Instantiate(prefab[Random.Range(0,prefab.Count)], startPoint, Quaternion.identity);
        startPoint.z += offset;
    }
}
