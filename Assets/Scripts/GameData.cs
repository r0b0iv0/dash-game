using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int coinsTotal;

    public bool[] skinsUnlocked;

    public GameData() {
        this.coinsTotal = 0;
        this.skinsUnlocked = new bool[5];
        this.skinsUnlocked[0] = true;
    }
}
