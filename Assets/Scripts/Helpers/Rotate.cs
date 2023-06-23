using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
  
      [SerializeField] private float speed;
    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(0,0, speed * Time.deltaTime, Space.World);
    }


}
