using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    private PlayerCollisions collisions;
    private PlayerMovement playerMovement;
    private GameManager gameManager;
    void Start()
    {
        this.collisions = FindObjectOfType<PlayerCollisions>();
        this.playerMovement = FindObjectOfType<PlayerMovement>();
        this.gameManager = FindObjectOfType<GameManager>();
    }
    public void PlayAgain()
    {   
        this.gameManager.ressetScore();
        this.collisions.RessetPositions();
        this.playerMovement.ressetMovement();
        this.gameObject.SetActive(false);
        //start the particle system so it continues to run
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<ParticleSystem>().Play();
    }

    public void MainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume() {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void Open() {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }
}
