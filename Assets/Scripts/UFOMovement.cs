using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovement : MonoBehaviour
{   
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.left * speed * Time.deltaTime);
    }
}
