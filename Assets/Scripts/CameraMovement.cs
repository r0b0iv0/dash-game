using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 100, transform.position.y, transform.position.z), cameraSpeed * Time.deltaTime);
        cameraSpeed += 0.0000000001f;
    }
}
