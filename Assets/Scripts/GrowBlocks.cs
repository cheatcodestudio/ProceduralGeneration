using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GrowBlocks : MonoBehaviour
{
    public GameObject prefab;
    public float offset = 1;
    public int maxCubeCount;    
    private List<GameObject> spawnObjects = new List<GameObject>();
    public List<Vector3> spawnPositions;
    private Vector3 cachedPosition;

    public void OnEnable()
    {
        ResetToDefaults();
    }
    public void Generate()
    {
        ResetToDefaults();

        for(int x = 0; spawnPositions.Count < maxCubeCount;x = spawnPositions.Count)
        {
            cachedPosition = GenerateRandomPosition(cachedPosition);
            if (IsValid(cachedPosition))
                spawnPositions.Add(cachedPosition);
        }
        for(int x = 0; x < spawnPositions.Count;x++)
        {
            spawnObjects.Add(Instantiate(prefab, spawnPositions[x], Quaternion.identity));
        }
    }
    private void ResetToDefaults()
    {
        cachedPosition = transform.position;
        for (int x = 0; x < spawnObjects.Count; x++)
            DestroyImmediate(spawnObjects[x]);
        spawnPositions.Clear();
        spawnObjects.Clear();
    }
    private Vector3 GenerateRandomPosition(Vector3 value)
    {
        int x = Random.Range(0, 4);
        Vector3 newRandomPosition = value;
        if (x == 0) newRandomPosition += new Vector3(0, 0,offset);
        else if(x == 1) newRandomPosition += new Vector3(0, 0,-offset);
        else if (x == 2) newRandomPosition += new Vector3(offset, 0,0);
        else if (x == 3) newRandomPosition += new Vector3(-offset, 0, 0);

        return newRandomPosition;
    }
    private bool IsValid(Vector3 value)
    {
        for(int x = 0; x < spawnPositions.Count;x++)
        {
            if (spawnPositions[x].x == value.x && spawnPositions[x].z == value.z)           
                return false;
        }
        return true;
    }
}
public enum Direction {North,South,East,West}
#if UNITY_EDITOR
[CustomEditor(typeof(GrowBlocks))]
public class GrowBlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var t = (target as GrowBlocks);

        base.OnInspectorGUI();
        if (GUILayout.Button("Generate"))
            t.Generate();
    }
}
#endif
