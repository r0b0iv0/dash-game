using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float timeBetweenSpawn;
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();
    private float lastSpawnTime;
    [SerializeField] private float TimeForCleanUp = 20;
    private float lastCleanUpTime = 20;
    private bool toSaveObjects = true;

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

    //             foreach (GameObject obstacle in OldObjects)
    //             {
    //                 Destroy(obstacle);
    //             }
    //             lastCleanUpTime = Time.time + TimeForCleanUp;
    //             toSaveObjects = true;

    //         }

    //     }
    // }


}
