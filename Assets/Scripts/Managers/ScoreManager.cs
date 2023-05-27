using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float Score {get; set;}
    void Start()
    {
        this.Score = 1;
    }

    void Update()
    {
    }

    public float scoreIncrement() {
        return Score += Mathf.Round(Score * Time.deltaTime);
    }

}
