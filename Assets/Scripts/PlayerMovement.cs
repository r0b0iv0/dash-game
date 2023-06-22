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
    public float velocity = 7.5f;
    [SerializeField]private float dashTime = 0.25f;
    [SerializeField]private float dashPower = 10f;
    [SerializeField]private float dashCooldown = 3f;

    private bool isDashing = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocity;
        animator.SetBool("Right", true);
    }
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(Dash());

        }

       
    }

    private void FixedUpdate() {

         if (isDashing == false) {
            rb.velocity = new Vector2(velocity + 0.00001f, rb.velocity.y);
        }
         
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(velocity + 0.00001f, (velocity * 0.6f));

        }
       
    }

    public void ressetMovement()
    {
        rb.velocity = new Vector2();
        rb.velocity = Vector2.right * velocity;
        animator.SetBool("Right", true);
    }

    private IEnumerator Dash() 
    {   
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x + dashPower, rb.velocity.y);
        rb.gravityScale = 0f;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        rb.gravityScale = 0.8f;
    }


}
