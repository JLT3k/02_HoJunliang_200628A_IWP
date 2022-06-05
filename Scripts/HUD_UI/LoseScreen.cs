using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("Restart");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");   
    }
}
