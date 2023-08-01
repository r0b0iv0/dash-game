using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGeneration : MonoBehaviour
{

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] public float timeBetweenSpawn;
    [SerializeField] private float asteroidSpeed;
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();
    private float lastSpawnTime;
    [SerializeField] private float TimeForCleanUp = 15;
    public float lastCleanUpTime = 15;

    private bool toSaveObjects = false;

    public static List<GameObject> objects = new List<GameObject>();
    public static List<GameObject> OldObjects = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawnTime)
        {
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY, maxY);

            int randomNum = Random.Range(0, objectsToSpawn.Count);

            GameObject gameObject = Instantiate(objectsToSpawn[randomNum], transform.position + new Vector3(x, y, 0), transform.rotation);
            float rand = Random.Range(-0.5f, 0.5f);
            gameObject.AddComponent<AsteroidMovement>().AddForceToAsteroid(asteroidSpeed, rand);
            objects.Add(gameObject);

            lastSpawnTime = Time.time + timeBetweenSpawn;
        }

        // CleanUp();

    }

    public static void DestroyObstacles()
    {
        foreach (GameObject obstacle in objects)
        {
            Destroy(obstacle);
        }
        objects.Clear();
    }

    // private void CleanUp()
    // {
    //     if (Time.time > lastCleanUpTime)
    //     {
    //         Debug.Log("time");
    //         if (toSaveObjects)
    //         {
    //             toSaveObjects = false;
    //             foreach (GameObject obstacle in objects)
    //             {
    //                 OldObjects.Add(obstacle);

    //             }

    //         }
    //         if (Time.time > lastCleanUpTime + 5)
    //         {
    //             Debug.Log("clean");
    //             foreach (GameObject obstacle in OldObjects)
    //             {
    //                 Destroy(obstacle);
    //             }
    //             lastCleanUpTime = Time.time + TimeForCleanUp;
    //             toSaveObjects = true;

    //         }

    //     }
    // }

    public void ressetCleanUp()
    {
        lastCleanUpTime = 0;
    }
}
