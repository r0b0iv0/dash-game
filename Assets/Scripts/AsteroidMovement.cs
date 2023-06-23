using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float rand1 = Random.value;
        float rand2 = Random.Range(-1, 2);
        
        rb.AddForce(new Vector2(-rand1, rand2) * speed * Time.deltaTime);


    }
}
