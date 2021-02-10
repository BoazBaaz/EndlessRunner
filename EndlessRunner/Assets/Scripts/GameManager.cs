using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject DeathCanvas;

    public TextMeshProUGUI EndScoreTxt;

    public bool gameOver = false;

    private int endScore;

    private void Awake()
    {
        instance = this;
        DeathCanvas.SetActive(false); // Hides the Death canvas.
    }

    public void ShowDeathScreen()
    {
        endScore = ScoreManager.instance.scoreAmount;
        DeathCanvas.SetActive(true); // Shows the death canvas.
        gameOver = true;
        EndScoreTxt.text = string.Format("Your Score: {0}", endScore);
    }
}
