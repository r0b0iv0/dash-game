using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int Coins { get; set; }
    public float Score { get; set; } = 0;
    private int scoreMultiplayer = 2;
    private int newHighScore = 0;
    private float lastSpeedIncrease = 20;
    private float intervalSpeedIncrease = 20;
    private GameData gameData = new GameData();
    private PlayerMovement playerMovementScript;
    [SerializeField] private Camera cam;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private List<GameObject> spawnersList = new List<GameObject>();
    [SerializeField] GameObject pauseButton;
    private List<GameObject> spawnersListCopies = new List<GameObject>();

    private void Awake()
    {
        this.gameData = SaveSystem.Load();
    }
    void Start()
    {
        playerMovementScript = FindObjectOfType<PlayerMovement>();
        // Debug.Log(Newtonsoft.Json.JsonConvert.SerializeObject(text));
        highScoreText.text = "Best: " + gameData.highScore.ToString();
        this.scoreMultiplayer = 2;
        InvokeRepeating("increaseGameSpeed", intervalSpeedIncrease, intervalSpeedIncrease);
        InvokeRepeating("spawnerGenerator", intervalSpeedIncrease * 1.5f, intervalSpeedIncrease * 1.5f);
    }

    void Update()
    {
        scoreText.text = System.Math.Ceiling(scoreIncrement()).ToString("N0");
        coinsText.text = "X " + (gameData.coinsTotal + Coins).ToString();
    }

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
        spawnerCleaner();
        // stops the particle system manually so it does not emit particles when paused
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<ParticleSystem>().Clear();
        player.GetComponentInChildren<ParticleSystem>().Stop();
        if (newHighScore != 0)
        {
            this.gameData.highScore = newHighScore;
            highScoreText.text = "Best: " + gameData.highScore.ToString();
        }        
        this.gameData.coinsTotal += Coins;
        Coins = 0;
        SaveSystem.Save(this.gameData);
    }

    private void GameOverScreen()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void ressetScore()
    {
        this.Score = 0;
    }

    private void increaseGameSpeed()
    {

        playerMovementScript.rightVelocity += 1.5f;
        lastSpeedIncrease += intervalSpeedIncrease;


    }

    private void spawnerGenerator()
    {
        float randTime = Random.Range(3, 5);
        int rand = Random.Range(0, 2);
        if (spawnersList[rand].TryGetComponent<ObstacleGeneration>(out ObstacleGeneration obstacleGeneration))
        {
            spawnersList[rand].GetComponent<ObstacleGeneration>().timeBetweenSpawn = randTime;
        }
        else
        {
            spawnersList[rand].GetComponent<AsteroidGeneration>().timeBetweenSpawn = randTime;
        }

        GameObject spawner = Instantiate(spawnersList[rand], new Vector3(cam.transform.position.x + 20, 0, cam.transform.position.z + 10), Quaternion.identity);
        spawnersListCopies.Add(spawner);
        spawner.transform.parent = cam.transform;



    }

    public void spawnerCleaner()
    {
        foreach (GameObject spawner in spawnersListCopies)
        {
            Destroy(spawner);
        }
    }
}
