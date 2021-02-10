using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        UIM = UIManager.instance;
    }

    [Header("GameInfo")]
    public bool m_GameOver = false;
    public int m_CurrentScore = 0;
    public int m_EndScore = 0;


    [Header("Coroutines")]
    public Coroutine m_PlatformCoroutine;
    public Coroutine m_ScoreCoroutine;

    //private
    UIManager UIM;

    private void Start()
    {
        UIM.m_DeathCanvas.SetActive(false); //disable the death canvas
        UIM.m_ScoreCanvas.SetActive(true); //enable the score canvas
    }

    public void ShowDeathScreen()
    {
        //stop spawning platforms
        StopCoroutine(m_PlatformCoroutine); 
        StopCoroutine(m_ScoreCoroutine);

        //set death
        UIM.m_DeathCanvas.SetActive(true); // Shows the death canvas.
        m_GameOver = true; //set gameover to true.

        //set the current score
        m_EndScore = m_CurrentScore; //set the endscore to the current score.
        UIM.m_EndScoreTxt.text = $"Your Score: {m_EndScore}";
    }
}
