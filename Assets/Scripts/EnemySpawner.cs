using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies; 
    public float spawnRate = 2f;
    private float timer = 0f;
    public float heightOffset = 10f; 

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        int randomIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[randomIndex], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity);
    }
}
