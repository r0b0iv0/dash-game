using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject player;
    private PlayerMovement playerMovementScript;
    private Vector3 camPos;
    private Vector3 playerPos;
    private GameManager gm;

    void Start()
    {   

        camPos = cam.transform.position;
        playerPos = player.transform.position;
        gm = FindObjectOfType<GameManager>();
        playerMovementScript = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DeadZone")
        {   
            gm.GameOver();
        }
        if(col.tag == "Coin") {
            Destroy(col.gameObject);
        }
        if(col.tag == "Point Increase") {
            Destroy(col.gameObject);
            gm.Score += 2;
        }
        if(col.gameObject.tag == "Enemy") {
            if(playerMovementScript.isDashing) {
                Destroy(col.gameObject); 
                //play enemy death animation  
            } else {
                Destroy(col.gameObject);
                // play player death animation
                gm.GameOver();
            }
            
        }
    }

    public void RessetPositions()
    {
        cam.transform.position = camPos;
        player.transform.position = playerPos;
        Time.timeScale = 1;
    }

}
