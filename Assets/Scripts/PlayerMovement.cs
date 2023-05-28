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
    public float dashPower = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * dashPower;
        animator.SetBool("Right", true);
    }
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

        // keyboard movement
        rb.velocity = new Vector2(rb.velocity.x + 0.00001f, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, (dashPower * 0.8f));

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, (-dashPower * 0.8f));

        }



        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {   
        //     gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2();
        //     animator.SetBool("Right", false);
        //     animator.SetBool("Left", true);
        //     rb.velocity = Vector2.left * dashPower;

        // }
    }

    public void ressetMovement()
    {
        rb.velocity = new Vector2();
        rb.velocity = Vector2.right * dashPower;
        animator.SetBool("Right", true);
    }


}
