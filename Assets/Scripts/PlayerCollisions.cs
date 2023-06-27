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
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Point Increase")
        {
            Destroy(col.gameObject);
            gm.Score += 2;
        }
        if (col.gameObject.tag == "Enemy")
        {
            Animator gameObjectAnimator = col.gameObject.GetComponent<Animator>();
            if (playerMovementScript.isDashing)
            {
                gameObjectAnimator.SetTrigger("Die");
            }
            else
            {

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
