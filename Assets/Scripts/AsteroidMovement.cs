using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    public void AddForceToAsteroid(float forceAmount, float direction) {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, direction) * forceAmount;
    }
}
