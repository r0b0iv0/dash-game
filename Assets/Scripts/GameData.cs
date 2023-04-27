using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coinsTotal;

    public int highScore;

    public GameData() {
        this.coinsTotal = 0;
        this.highScore = 0;
    }
}
