using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private PlayerCollisions collisions;
    private PlayerMovement playerMovement;
    private GameManager gameManager;
    [SerializeField] GameObject pauseButton;
    void Start()
    {
        this.collisions = FindObjectOfType<PlayerCollisions>();
        this.playerMovement = FindObjectOfType<PlayerMovement>();
        this.gameManager = FindObjectOfType<GameManager>();
    }
    public void PlayAgain()
    {   
        this.gameManager.ressetScore();
        this.gameManager.highScoreText.enabled = false;
        this.gameManager.rubyCountParent.GetComponent<Animator>().SetBool("Move", false);
        this.collisions.RessetPositions();
        this.playerMovement.ressetMovement();
        this.gameObject.SetActive(false);
        //start the particle system so it continues to run
        GameObject player = GameObject.FindWithTag("Player");
        pauseButton.SetActive(true);
        player.GetComponentInChildren<ParticleSystem>().Play();
    }

    public void MainMenu() {
        Time.timeScale = 1;
        AsteroidGeneration.DestroyObstacles();
        ObstacleGeneration.DestroyObstacles();
        gameManager.spawnerCleaner();
        this.gameManager.ressetScore();
        this.collisions.RessetPositions();
        this.playerMovement.ressetMovement();
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume() {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
