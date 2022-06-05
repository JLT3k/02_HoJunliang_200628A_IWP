using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject gameUI;

    private void Start()
    {
        loseScreen.SetActive(false);
        gameUI.SetActive(true);
    }
    public void ShowDeathScreen()
    {
        loseScreen.SetActive(true);
    }
}
