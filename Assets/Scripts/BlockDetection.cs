using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDetection : MonoBehaviour
{
    [SerializeField]
    protected AppendBlock aBlock;
    [SerializeField]
    protected Direction direction;

    [ExecuteInEditMode]
    private void OnTriggerEnter(Collider other)
    {
        if (direction == Direction.North)
            aBlock.NorthTriggered();
        else if (direction == Direction.South)
            aBlock.SouthTriggered();
        else if (direction == Direction.East)
            aBlock.EastTriggered();
        else if (direction == Direction.West)
            aBlock.WestTriggered();
    }

    public enum Direction { North,South,East,West}
}
