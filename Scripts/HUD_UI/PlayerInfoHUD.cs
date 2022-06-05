using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInfoHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TextMeshProUGUI healthText;

    float healthBarLength;
    private void Start()
    {
        healthBarLength = healthBar.rectTransform.sizeDelta.x;
    }

    public void UpdateHealthBar(int hp, int maxHP)
    {
        healthText.text = hp + " / " + maxHP;
        healthBar.rectTransform.sizeDelta = new Vector2((hp / (float)maxHP) * healthBarLength, healthBar.rectTransform.sizeDelta.y);
    }
}
