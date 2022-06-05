using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour, IDamagable
{
    public void TakeDamage()
    {

    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
