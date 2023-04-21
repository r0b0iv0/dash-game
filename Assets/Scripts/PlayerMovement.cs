using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] private Animator animator;
    private Vector2 startPos;
    private Vector2 endPos;
    private Touch touch;
    public int pixelForTouchToCount = 20;
    private bool fingerDown;
    private bool dashed = false;
    public float dashPower = 10;
    public float startDashTime = 0;
    private float dashTime;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }
    // Update is called once per frame
    void Update()
    {    
        // mobile movement
        // if (Input.touches.Length > 0)
        // {
        //     fingerDown = true;
        //     dashed = false;
        //     touch = Input.touches[0];
        //     if (touch.phase == TouchPhase.Began)
        //     {
        //         Debug.Log(touch.position);
        //         startPos = touch.position;
        //     }

        // }
        // if (dashed)
        // {
        //     dashTime -= Time.deltaTime;
        // }
        // if (dashTime <= 0)
        // {
        //     dashTime = startDashTime;
        //     Debug.Log("stop");
        //     rb.velocity = Vector2.zero;
        // }
        // else
        // {
        //     if (fingerDown && touch.phase == TouchPhase.Ended)
        //     {
        //         endPos = touch.position;
        //         if (startPos.y <= endPos.y - pixelForTouchToCount)
        //         {
        //             Debug.Log("Swipe Up");
        //             fingerDown = false;
        //             dashed = true;
        //             rb.velocity = Vector2.up * dashPower;

        //         }
        //         if (startPos.y >= endPos.y + pixelForTouchToCount)
        //         {
        //             Debug.Log("Swipe Down");
        //             fingerDown = false;
        //             dashed = true;
        //             rb.velocity = Vector2.down * dashPower;

        //         }
        //         if (startPos.x <= endPos.x - pixelForTouchToCount)
        //         {
        //             Debug.Log("Swipe right");
        //             fingerDown = false;
        //             dashed = true;
        //             rb.velocity = Vector2.right * dashPower;

        //         }
        //         if (startPos.x >= endPos.x + pixelForTouchToCount)
        //         {
        //             Debug.Log("Swipe left");
        //             fingerDown = false;
        //             dashed = true;
        //             rb.velocity = Vector2.left * dashPower;

        //         }
        //     }
        // }
     if (dashed)
        {
            dashTime -= Time.deltaTime;
        }
        if (dashTime <= 0)
        {
            dashTime = startDashTime;
            // rb.velocity = Vector2.zero;
            animator.SetBool("Right", false);
            animator.SetBool("Up", false);
            animator.SetBool("Left", false);
            animator.SetBool("Down", false);
            dashed = false;
        }
        else
        {
            // keyboard movement
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetBool("Up", true);
                rb.velocity = Vector2.up * dashPower;
                dashed = true;

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.SetBool("Down", true);
                rb.velocity = Vector2.down * dashPower;
                dashed = true;

            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                animator.SetBool("Right", true);
                rb.velocity = Vector2.right * dashPower;
                dashed = true;

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                animator.SetBool("Left", true);
                rb.velocity = Vector2.left * dashPower;
                dashed = true;

            }
        }

    }
}
