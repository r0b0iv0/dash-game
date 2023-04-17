using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int Coins {get; set;}
    private GameData gameData = new GameData();
    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        this.gameData = SaveSystem.Load();
    }
    void Start()
    {
        // Debug.Log(Newtonsoft.Json.JsonConvert.SerializeObject(text));
        gameData = SaveSystem.Load();
        text.text = "X " + gameData.coinsTotal;
    }

    void Update()
    {
        text.text = "X " + (gameData.coinsTotal + Coins).ToString();
    }

    public void CollectCoins()
    {
        Coins += 1;
    }

    public void GameOver()
    {
        // this.gameData.coinsTotal = (GetComponent<TextMeshProUGUI>().text.Split(' ')[1])
        this.gameData.coinsTotal += Coins;
        SaveSystem.Save(this.gameData);
    }
}
