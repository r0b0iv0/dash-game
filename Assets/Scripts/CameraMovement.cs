using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private int depthOffSet = -10;
    [SerializeField] private int xOffSet = 6;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + xOffSet, 0, depthOffSet);
    }
}
