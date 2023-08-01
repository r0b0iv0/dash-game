using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator barAnimator;
    private Vector2 startPos;
    private Vector2 endPos;
    private Touch touch;
    public int pixelForTouchToCount = 40;
    private bool fingerDown;
    public float velocity = 7.5f;
    public float defeaultVelocity = 7.5f;
    public float rightVelocity = 7.5f;
    private ParticleSystem particleSystem;
    private SoundManager soundManager;
    [SerializeField] private float dashTime = 0.25f;
    [SerializeField] private float dashPower = 10f;
    [SerializeField] private float dashCooldown = 2f;
    private bool canDash = true;

    public bool isDashing = false;


    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        soundManager = FindObjectOfType<SoundManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * velocity;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.touchCount > 0)
        {

            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    touch = Input.GetTouch(0);
                    startPos = Input.GetTouch(0).position;
                    break;
                case TouchPhase.Ended:

                    endPos = Input.GetTouch(0).position;

                    if (startPos.x + pixelForTouchToCount <= endPos.x && canDash)
                    {
                        StartCoroutine(Dash());
                    }
                    else
                    {
                        rb.velocity = new Vector2(rightVelocity, (velocity * 0.6f));
                    }
                    break;



            }


        }


    }


    void FixedUpdate()
    {


        if (isDashing == false)
        {
            rb.velocity = new Vector2(rightVelocity, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rightVelocity, (velocity * 0.6f));

        }



    }

    public void ressetMovement()
    {
        rb.velocity = new Vector2();
        rightVelocity = defeaultVelocity;
        rb.velocity = Vector2.right * defeaultVelocity;
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        animator.SetBool("Attack", true);
        rb.velocity = new Vector2(rb.velocity.x + dashPower, rb.velocity.y);
        soundManager.playAttackSound();
        particleSystem.Emit(10);
        rb.gravityScale = 0f;

        yield return new WaitForSeconds(dashTime);
        animator.SetBool("Attack", false);
        barAnimator.SetBool("hasDashed", true);
        isDashing = false;
        rb.gravityScale = 0.8f;

        yield return new WaitForSeconds(dashCooldown);
        barAnimator.SetBool("hasDashed", false);
        canDash = true;
    }


}
