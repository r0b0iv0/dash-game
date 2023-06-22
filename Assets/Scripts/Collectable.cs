using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour
{   
    private GameManager gm;

    void Start() {
        gm = FindObjectOfType<GameManager>();  
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Coin") {
            Destroy(col.gameObject);
        }
        if(col.tag == "Point Increase") {
            Destroy(col.gameObject);
            gm.Score += 2;
        }
    }
}
