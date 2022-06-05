using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorInteraction : MonoBehaviour
{
    GridManager gridManager;

    private void Start()
    {
        //gridManager = FindObjectOfType<GridManager>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse1))
        //{
        //    Vector3 gridPos = gridManager.NodeFromWorldPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).worldPosition;
        //    foreach (var entity in GameObject.Find("Entities").transform.GetComponentsInChildren<MovableEntities>())
        //    {
        //        if (entity.transform.position.Equals(gridPos))
        //        {
        //            Debug.Log("On Entity");
        //            //if (entity.GetComponent<EnemyAI>())
        //            {
        //                string info = "";
        //                info = "HP: " + entity.GetComponent<Health>().GetHP();
        //                info += "\nDamage: " + entity.GetComponent<MovableEntities>().damage;
        //                Debug.Log(info);
        //            }
        //            break;
        //        }
        //    }
        //}
    }
}
