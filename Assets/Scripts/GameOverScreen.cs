using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private Respawn respawn;
    void Start()
    {
        this.respawn = FindObjectOfType<Respawn>();
    }
    public void PlayAgain()
    {
        gameObject.SetActive(false);
        respawn.RessetPositions();
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
