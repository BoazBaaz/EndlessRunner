using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreTxt;
    public float scoreAmount = 0f;

    private void Start()
    {
        ScoreTxt.text = string.Format("Score: {0}", scoreAmount);
        StartCoroutine("AddScore");
    }

    IEnumerator AddScore()
    {
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
