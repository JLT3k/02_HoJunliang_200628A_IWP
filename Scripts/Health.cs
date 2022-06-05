using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int hp;
    public int maxHP;

    private void Start()
    {
        hp = maxHP;
    }
    public void UpdateHP(int value)
    {
        if (value > 0 && hp < maxHP)
            FindObjectOfType<TextBox>().DisplayMessage(gameObject.name + " Regenerating...");
        hp += value;
        if (value < 0) GetComponent<IDamagable>().TakeDamage();
        if (hp > maxHP) hp = maxHP;
        if (hp <= 0)
        {
            GetComponent<IDamagable>().Die();
        }
    }
    public int GetHP()
    {
        return hp;
    }
}
