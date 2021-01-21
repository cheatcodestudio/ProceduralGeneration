using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class AppendBlock : MonoBehaviour
{
    [SerializeField]
    public int max;
    [SerializeField]
    protected List<AppendBlock> blockListA,blockListB,blockListC,blockListD;
    [SerializeField]
    protected List<Vector3> locations;
    private bool bNorth, bSouth, bEast, bWest;
    private AppendBlock newBlock;

    public void AddBlock(int maxCount,int currentCount)
    {
        if (currentCount >= max) return;
        for (int x = 0; x < locations.Count; x++)
        {
            if (x == 0)
            {
                currentCount++;
                newBlock = Instantiate(blockListA[Random.Range(0, blockListA.Count)], locations[x] + transform.position, Quaternion.identity) as AppendBlock;
                newBlock.AddBlock(maxCount, currentCount);
            }
            else if (x == 1)
            {
                currentCount++;
                newBlock = Instantiate(blockListB[Random.Range(0, blockListB.Count)], locations[x] + transform.position, Quaternion.identity) as AppendBlock;
                newBlock.AddBlock(maxCount, currentCount);
            }
            else if (x == 2)
            {
                currentCount++;
                newBlock = Instantiate(blockListC[Random.Range(0, blockListC.Count)], locations[x] + transform.position, Quaternion.identity) as AppendBlock;
                newBlock.AddBlock(maxCount, currentCount);
            }
            else if (x == 3)
            {
                currentCount++;
                newBlock = Instantiate(blockListD[Random.Range(0, blockListD.Count)], locations[x] + transform.position, Quaternion.identity) as AppendBlock;
                newBlock.AddBlock(maxCount, currentCount);
            }            
        }
        Debug.Log(currentCount+ " " +maxCount);
    }
    public void Generate()
    {
        AddBlock(max, 0);
    }
    public void NorthTriggered() { bNorth = true; }
    public void SouthTriggered() { bSouth = true; }
    public void EastTriggered() { bEast = true; }
    public void WestTriggered() { bWest = true; }
}
#if UNITY_EDITOR
[CustomEditor(typeof(AppendBlock))]
public class AppendBlockEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var t = (target as AppendBlock);

        base.OnInspectorGUI();
        if (GUILayout.Button("Generate"))
            t.Generate();
    }
}
#endif
