using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        GM = GameManager.instance;
    }

    [Header("Canvas Objects")]
    public GameObject m_DeathCanvas;
    public GameObject m_ScoreCanvas;

    [Header("Text")]
    public TextMeshProUGUI m_EndScoreTxt;
    public TextMeshProUGUI m_CurrentScoreTxt;

    //private
    private GameManager GM;

    private void Start()
    {
        //start the coroutine.
        GM.m_ScoreCoroutine = StartCoroutine(AddScore());
    }

    IEnumerator AddScore()
    {
        //repeatedly add one score to the variable every second.
        while (!GM.m_GameOver)
        {
            GM.m_CurrentScore++;
            m_CurrentScoreTxt.text = $"Score: {GM.m_CurrentScore}";

            //wait for one second
            yield return new WaitForSeconds(1);
        }
    }
}
