using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridNode : IHeapItem<GridNode>
{
    public int gridX, gridY, gCost, hCost;
    public Vector3 worldPosition;
    public bool walkable;
	public GridNode parent;

	int heapIndex;

    public GridNode(Vector3 worldPosition, bool walkable, int gridX, int gridY)
    {
        this.worldPosition = worldPosition;
        this.walkable = walkable;
        this.gridX = gridX;
        this.gridY = gridY;
    }
	public int fCost
	{
		get
		{
			return gCost + hCost;
		}
	}

	public int HeapIndex
	{
		get
		{
			return heapIndex;
		}
		set
		{
			heapIndex = value;
		}
	}
	public int CompareTo(GridNode nodeToCompare)
	{
		int compare = fCost.CompareTo(nodeToCompare.fCost);
		if (compare == 0)
		{
			compare = hCost.CompareTo(nodeToCompare.hCost);
		}
		return -compare;
	}
}
