using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject DeathCanvas;
    public bool isDead = false;

    private void Awake()
    {
        instance = this;
        DeathCanvas.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        DeathCanvas.SetActive(true);
        isDead = true;
    }
}
