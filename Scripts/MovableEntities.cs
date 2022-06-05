using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all entities that can use a turn
abstract public class MovableEntities : MonoBehaviour, IDamagable
{
    protected GridManager gridManager;
    protected List<GridNode> path;
    protected ASPathFinding pathFinder;

    public bool endTurn = false;

    public int damage;

    // things to do for each turn
    public abstract IEnumerator TurnUpdate();

    public void Damage(Health target)
    {
        target.UpdateHP(-damage);
    }
    public abstract void Die();
    public abstract void TakeDamage();
}
