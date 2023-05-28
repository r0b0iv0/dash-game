using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private Respawn respawn;
    private PlayerMovement playerMovement;
    private GameManager gameManager;
    void Start()
    {
        this.respawn = FindObjectOfType<Respawn>();
        this.playerMovement = FindObjectOfType<PlayerMovement>();
        this.gameManager = FindObjectOfType<GameManager>();
    }
    public void PlayAgain()
    {   
        this.gameManager.ressetScore();
        this.respawn.RessetPositions();
        this.playerMovement.ressetMovement();
        this.gameObject.SetActive(false);
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
