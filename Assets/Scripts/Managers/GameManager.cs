using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int Coins { get; set; }
    public float Score { get; set; }
    private int scoreMultiplayer = 2;
    private int newHighScore = 0;
    private float lastSpeedIncrease = 20;
    private float intervalSpeedIncrease = 20;
    private GameData gameData = new GameData();
    private PlayerMovement playerMovementScript;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private List<GameObject> spawnersList;

    private void Awake()
    {
        this.gameData = SaveSystem.Load();
    }
    void Start()
    {
        playerMovementScript = FindObjectOfType<PlayerMovement>();
        // Debug.Log(Newtonsoft.Json.JsonConvert.SerializeObject(text));
        gameData = SaveSystem.Load();
        // scoreText.text = "X " + gameData.coinsTotal;
        scoreText.text = "Score: 0";
        highScoreText.text = "High Score: " + gameData.highScore.ToString();
        this.scoreMultiplayer = 2;
    }

    void Update()
    {
        increaseGameSpeed();
        scoreText.text = "Score: " + System.Math.Ceiling(scoreIncrement()).ToString("N0");
    }

    // public void CollectCoins()
    // {
    //     Coins += 1;
    // }

    public float scoreIncrement()
    {
        Score += scoreMultiplayer * Time.deltaTime;
        if (gameData.highScore < Score)
        {
            newHighScore = (int)System.Math.Ceiling(Score);
        }
        return Score;
    }

    public void GameOver()
    {
        this.GameOverScreen();
        AsteroidGeneration.DestroyObstacles();
        ObstacleGeneration.DestroyObstacles();
        // stops the particle system manually so it does not emit particles when paused
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<ParticleSystem>().Clear();
        player.GetComponentInChildren<ParticleSystem>().Stop();
        if (newHighScore != 0)
        {
            this.gameData.highScore = newHighScore;
            highScoreText.text = "High Score: " + gameData.highScore.ToString();
        }
        SaveSystem.Save(this.gameData);
    }

    private void GameOverScreen()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }

    public void ressetScore()
    {
        this.Score = 0;
    }

    private void increaseGameSpeed()
    {
        if (Time.time > lastSpeedIncrease)
        {
            playerMovementScript.rightVelocity += 1.5f;
            lastSpeedIncrease += intervalSpeedIncrease;

            spawnerGenerator();
        }

    }

    private void spawnerGenerator()
    {
        int rand = Random.Range(0, 1);
        Debug.Log(rand);

        GameObject spawner = Instantiate(spawnersList[rand], new Vector3(cam.transform.position.x + 20, 0, cam.transform.position.z + 10), Quaternion.identity);
        spawner.transform.parent = cam.transform;

    }
}
