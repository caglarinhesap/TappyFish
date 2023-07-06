using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject obstacle;
    float spawnTime;
    public float maxSpawnTime;
    public float minSpawnTime;
    float timer;
    public float maxY;
    public float minY;
    float randomY;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameOver && GameManager.gameStarted)
        {
            timer += Time.deltaTime;
            spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            if (timer >= spawnTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObstacle();
                timer = 0;
            }
        }
    }

    public void InstantiateObstacle()
    {
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randomY);
    }

}
