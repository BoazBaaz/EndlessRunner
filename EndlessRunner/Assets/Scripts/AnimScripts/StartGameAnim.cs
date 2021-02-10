using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartGameAnim : MonoBehaviour
{
    public static StartGameAnim instance;

    public Animator animator;

    public AudioSource audio;

    public GameObject StartButton;
    public GameObject QuitButton;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void StartAnim()
    {
        animator.SetBool("start", true);
        audio.Play();
        StartCoroutine("WaitToStart");
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1);
        StartButton.SetActive(false);
        QuitButton.SetActive(false);
        yield return new WaitForSeconds(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        StopCoroutine("WaitToStart");
    }

}
