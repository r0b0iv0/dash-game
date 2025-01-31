using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementMenu : MonoBehaviour
{
    [SerializeField] public float timeToDestination = 0.05f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), timeToDestination * Time.deltaTime);
    }
}
