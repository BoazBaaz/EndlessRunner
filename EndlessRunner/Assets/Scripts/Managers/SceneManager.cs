using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    /// <summary>
    /// Start the startgame animation.
    /// </summary>
    public void StartGame()
    {
        StartGameAnim.instance.StartAnim();
    }

    /// <summary>
    /// Reload the current scene.
    /// </summary>
    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Load the selected scene using the build index.
    /// </summary>
    /// <param name="_scene">Selected scene</param>
    public void LoadScene(int _scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_scene);
    }

    /// <summary>
    /// Load the next scene in the build index.
    /// </summary>
    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Close the application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
