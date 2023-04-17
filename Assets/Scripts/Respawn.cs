using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameOverScreen;
    private Vector3 camPos;
    private Vector3 playerPos;
    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        camPos = cam.transform.position;
        playerPos = player.transform.position;
        gm = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "DeadZone")
        {   
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
            gameOverScreen.SetActive(true);
            gm.GameOver();
            gm.Coins = 0;
            ObstacleGeneration.DestroyObstacles();
        }
    }

    public void RessetPositions()
    {
        cam.transform.position = camPos;
        player.transform.position = playerPos;
        Time.timeScale = 1;
    }
}
