using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridOutline : MonoBehaviour
{
    [SerializeField] GameObject availableOutline, occupiedOutline;
    GridManager gridManager;

    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
    }
    private void Update()
    {
        GridNode node = gridManager.NodeFromWorldPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (node != null)
        {
            availableOutline.SetActive(node.walkable);
            occupiedOutline.SetActive(!availableOutline.activeSelf);
            transform.position = node.worldPosition;

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log(node.worldPosition + ", " + node.gridX + ", " + node.gridY);
            }
        }
    }
}
