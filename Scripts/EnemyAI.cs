using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MovableEntities
{
    GameObject player;
    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = new ASPathFinding();
        player = FindObjectOfType<PlayerBehaviour>().gameObject;
    }

    public override IEnumerator TurnUpdate()
    {
        endTurn = false;
        //FindObjectOfType<TextBox>().DisplayMessage("Enemy's Turn");

        if (IsAdjacent(player.transform.position))
        {
            Attack();
        }
        else
        {
            Chase();
        }

        yield return new WaitUntil(() => endTurn);
    }
    void Attack()
    {
        path = null;
        player.GetComponent<Health>().UpdateHP(-damage);
        FindObjectOfType<TextBox>().DisplayMessage("Enemy attacked Player for " + damage + " hp.");
        endTurn = true;
    }
    void Chase()
    {
        path = pathFinder.FindPath(transform.position, player.transform.position, gridManager);
        transform.position = path[0].worldPosition;
        path.RemoveAt(0);
        if (path.Count < 1) path = null;

        endTurn = true;
    }

    bool IsAdjacent(Vector3 targetPosition)
    {
        return (Mathf.Abs(Vector3.Magnitude(targetPosition - transform.position)) < 2);
    }

    public override void TakeDamage()
    {
        
    }
    public override void Die()
    {
        FindObjectOfType<TextBox>().DisplayMessage(name + " has died.");
        Destroy(gameObject);
    }
}
