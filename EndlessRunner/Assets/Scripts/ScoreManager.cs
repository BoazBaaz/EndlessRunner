using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public GameObject Score;
    public TextMeshProUGUI ScoreTxt;
    public int scoreAmount = 0;

    private void Awake()
    {
        instance = this;

        // Sets the given variable to the given string plus variable, and starts the coroutine.
        ScoreTxt.text = string.Format("Score: {0}", scoreAmount);
        StartCoroutine("AddScore");
    }

    private void Update()
    {
        // Stops coroutine when player died.
        if (GameManager.instance.isDead)
        {
            StopCoroutine("AddScore");
        }
    }

    IEnumerator AddScore()
    {
        // Repeatedly adds one score to the variable every one second.

        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                scoreAmount++;
                ScoreTxt.text = string.Format("Score: {0}", scoreAmount);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
