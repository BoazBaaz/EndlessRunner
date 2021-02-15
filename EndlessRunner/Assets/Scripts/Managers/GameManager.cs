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
    }

    [Header("GameInfo")]
    public bool m_GameOver = false;
    public int m_CurrentScore = 0;
    public int m_EndScore = 0;

    [Header("Bounds")]
    public float m_YBounds = 7f;
    public float m_XBounds = 8f;

    [Header("GameObjects")]
    public GameObject m_FadeInPanel;

    //private
    UIManager UIM;

    private void Start()
    {
        //instance of the uimanager
        UIM = UIManager.instance;

        UIM.m_DeathCanvas.SetActive(false); //disable the death canvas
        UIM.m_ScoreCanvas.SetActive(true); //enable the score canvas

        m_FadeInPanel.SetActive(true); //enables the fade-in canvas
        FadeInAnim.instance.FadeIn(); //calls the fade-in function from the FadeInAnim script
    }

    public void ShowDeathScreen()
    {
        //set death
        m_GameOver = true; //set gameover to true.
        UIM.m_DeathCanvas.SetActive(true); //shows the death canvas.
        UIM.m_ScoreCanvas.SetActive(false); //enable the score canvas

        //set the current score
        m_EndScore = m_CurrentScore; //set the endscore to the current score.
        UIM.m_EndScoreTxt.text = $"Your Score: {m_EndScore}";
    }
}
