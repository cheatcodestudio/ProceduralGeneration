using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfficientTempleRun : MonoBehaviour
{
    public float speed = 3;
    public Vector3 startPoint;
    public float offset;
    public List<GameObject> levelPrefabs;

    private void FixedUpdate()
    {
        transform.localPosition += Vector3.forward * Time.deltaTime * speed;
    }
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.SetActive(false);
        SpawnNewBlock();
    }
    private void SpawnNewBlock()
    {
        for (int x = 0; x < levelPrefabs.Count; x++)
        {
            if (!levelPrefabs[x].activeSelf)
            {
                levelPrefabs[x].transform.position = startPoint;
                levelPrefabs[x].SetActive(true);
                startPoint.z += offset;
            }
        }
    }
}
