using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{   
    private GameObject player;
    private bool hit = false;
    [SerializeField] private float collectSpeed;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Magnet")
        {
            hit = true;
            Debug.Log("hit");
        }
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate() {
        if (hit) {
            Debug.Log(player.transform.position);
            transform.position = Vector2.Lerp(transform.position, player.transform.position, collectSpeed * Time.deltaTime);
        }
        
    }
}