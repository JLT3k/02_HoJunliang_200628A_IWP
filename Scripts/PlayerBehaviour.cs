using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MovableEntities
{
    int restCount = 0;
    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = new ASPathFinding();
    }
    private void Update()
    {
        if (endTurn) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rest();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Inventory>().DropItem();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector3.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject entity = IsOccupied(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (entity != null && entity.GetComponent<Health>() && entity != gameObject && Mathf.Abs(Vector3.Magnitude(entity.transform.position - transform.position)) < 2)
            {
                Damage(entity.GetComponent<Health>());
                FindObjectOfType<TextBox>().DisplayMessage("Player attacked " + entity.name + " for " + damage + " hp.");
                restCount = 0;
                endTurn = true;
            }
            else path = pathFinder.FindPath(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), gridManager);
        }
        if (path != null)
        {
            MoveWithPathFinder();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Vector3 gridPos = gridManager.NodeFromWorldPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).worldPosition;
            foreach (var entity in GameObject.Find("Entities").transform.GetComponentsInChildren<MovableEntities>())
            {
                if (entity.transform.position.Equals(gridPos))
                {
                    Debug.Log("On Entity");
                    //if (entity.GetComponent<EnemyAI>())
                    {
                        string info;
                        info = "HP: " + entity.GetComponent<Health>().GetHP();
                        info += "\nDamage: " + entity.GetComponent<MovableEntities>().damage;
                        FindObjectOfType<TextBox>().DisplayMessage(info);
                    }
                    break;
                }
            }
        }
    }
    public override IEnumerator TurnUpdate()
    {
        endTurn = false;

        yield return new WaitUntil(() => endTurn);
    }

    void Move(Vector3 direction)
    {
        if (gridManager.CheckWalkable(transform.position + direction))
        {
            transform.position += direction;
            endTurn = true;
        }
    }
    void MoveWithPathFinder()
    {
        if (path != null)
        {
            transform.position = path[0].worldPosition;
            path.RemoveAt(0);
            if (path.Count < 1) path = null;
            endTurn = true;
        }
    }
    void Rest()
    {
        restCount++;
        if (restCount > 3)
        {
            GetComponent<Health>().UpdateHP(1);
            FindObjectOfType<PlayerInfoHUD>().UpdateHealthBar(GetComponent<Health>().GetHP(), GetComponent<Health>().maxHP);
        }
        endTurn = true;
    }
    GameObject IsOccupied(Vector3 worldPosition)
    {
        Vector3 gridPos = gridManager.NodeFromWorldPoint(worldPosition).worldPosition;
        foreach (var entity in GameObject.Find("Entities").transform.GetComponentsInChildren<Transform>())
        {
            if (entity.transform.position.Equals(gridPos))
            {
                Debug.Log("On Entity");
                return entity.gameObject;
            }
        }
        return null;
    }

    public override void Die()
    {
        FindObjectOfType<TextBox>().DisplayMessage("Player has died");
        FindObjectOfType<UIManager>().ShowDeathScreen();
    }
    public override void TakeDamage()
    {
        FindObjectOfType<PlayerInfoHUD>().UpdateHealthBar(GetComponent<Health>().GetHP(), GetComponent<Health>().maxHP);
    }
}
