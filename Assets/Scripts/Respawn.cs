using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject player;
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DeadZone")
        {   
            gm.GameOver();
        }
    }

    public void RessetPositions()
    {
        cam.transform.position = camPos;
        player.transform.position = playerPos;
        Time.timeScale = 1;
    }
}
