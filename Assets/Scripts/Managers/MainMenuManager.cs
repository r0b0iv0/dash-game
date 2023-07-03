using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private LevelLoader loader;
    void Start()
    {
        loader = FindObjectOfType<LevelLoader>();
    }
    public void PlayGame()
    {
        loader.GetComponentInParent<Animator>().enabled = true;
        Time.timeScale = 1;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        loader.StartTransition();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
