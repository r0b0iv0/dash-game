using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float depthOffSet = -10;
    [SerializeField] private float xOffSet = 6;
    [SerializeField] public float timeToDestination = 0.6f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + xOffSet, transform.position.y, depthOffSet), timeToDestination);
    }
}
