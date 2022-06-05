using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    [SerializeField] Tilemap groundTiles, collisionTiles;

    // position off set of the grid game object
    [SerializeField] GameObject gridMap;

    public Vector2Int gridWorldSize;

    GridNode[,] grid;

    bool drawGizmos = false;

    public List<GridNode> path;

    public int maxSize
    {
        get 
        { 
            return gridWorldSize.x * gridWorldSize.y; 
        }
    }

    private void Start()
    {
        drawGizmos = true;
        CreateGrid();
    }
    void CreateGrid()
    {
        grid = new GridNode[gridWorldSize.x, gridWorldSize.y];
        Vector3 worldBottomLeft = Vector3.left * Mathf.FloorToInt(gridWorldSize.x * .5f) + Vector3.down * Mathf.FloorToInt(gridWorldSize.y * .5f);

        for (int x = 0; x < gridWorldSize.x; x++)
        {
            for (int y = 0; y < gridWorldSize.y; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * x + Vector3.up * y;
                grid[x, y] = new GridNode(worldPoint, CheckWalkable(worldPoint), x, y);
            }
        }
    }
    public bool CheckWalkable(Vector3 position)
    {
        Vector3Int gridPos = Vector3Int.FloorToInt(position);
        return (groundTiles.HasTile(gridPos) && !collisionTiles.HasTile(gridPos));
    }
    public List<GridNode> GetNeighbours(GridNode node)
    {
        List<GridNode> neighbours = new List<GridNode>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                    continue;

                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridWorldSize.x && checkY >= 0 && checkY < gridWorldSize.y)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }

        return neighbours;
    }
    public GridNode NodeFromWorldPoint(Vector3 worldPosition)
    {
        Vector2Int gridPos = Vector2Int.FloorToInt(worldPosition - gridMap.transform.position);
        int x = gridPos.x + Mathf.FloorToInt(gridWorldSize.x * .5f);
        int y = gridPos.y + Mathf.FloorToInt(gridWorldSize.y * .5f);
        if (x < gridWorldSize.x && y < gridWorldSize.y && x >= 0 && y >= 0)
            return grid[x, y];
        else return null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(gridMap.transform.position, new Vector3(gridWorldSize.x, gridWorldSize.y, 0));
        if (drawGizmos)
        {
            foreach (GridNode n in grid)
            {
                Gizmos.color = (n.walkable) ? Color.white : Color.red;
                if (path != null)
                    if (path.Contains(n))
                        Gizmos.color = Color.black;
                Gizmos.DrawCube(n.worldPosition, Vector3.one);
            }
        }
    }
}
