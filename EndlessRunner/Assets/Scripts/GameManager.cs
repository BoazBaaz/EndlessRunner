using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject DeathCanvas;

    private void Awake()
    {
        instance = this;
        DeathCanvas.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        DeathCanvas.SetActive(true);
    }
}
