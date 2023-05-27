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
    private GameData gameData = new GameData();
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        this.gameData = SaveSystem.Load();
    }
    void Start()
    {
        // Debug.Log(Newtonsoft.Json.JsonConvert.SerializeObject(text));
        gameData = SaveSystem.Load();
        // scoreText.text = "X " + gameData.coinsTotal;
        scoreText.text = "Score: 0";
        highScoreText.text = "High Score: " + gameData.highScore.ToString();
        this.scoreMultiplayer = 2;
    }

    void Update()
    {
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
        // this.gameData.coinsTotal = (GetComponent<TextMeshProUGUI>().text.Split(' ')[1])
        // this.gameData.coinsTotal += Coins;
        this.GameOverScreen();
        ObstacleGeneration.DestroyObstacles();
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
}
