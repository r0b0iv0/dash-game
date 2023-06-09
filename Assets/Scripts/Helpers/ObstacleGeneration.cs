using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{

    [SerializeField] private GameObject obstacle;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float timeBetweenSpawn;
    private float lastSpawnTime;

    public static List<GameObject> objects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnTime)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            GameObject gameObject = Instantiate(obstacle, transform.position + new Vector3(x, y, 0), transform.rotation);
            objects.Add(gameObject);

            lastSpawnTime = Time.time + timeBetweenSpawn;
        }

    }

    public static void DestroyObstacles() {
        foreach(GameObject obstacle in objects) {
            Destroy(obstacle);
        }
        objects.Clear();
    }
}
