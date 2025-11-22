using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawner : MonoBehaviour
{
    public GameObject[] spritePrefabs; // Array to hold your sprite prefabs
    public Vector3 spawnAreaMin; // Minimum bounds for random spawn position
    public Vector3 spawnAreaMax; // Maximum bounds for random spawn position
    public GameObject special;
    public int specialSpawnNumber = 0;

    // Call this method to spawn a random sprite
    public void SpawnRandomSprite()
    {
        if (spritePrefabs.Length == 0)
        {
            Debug.LogWarning("No sprite prefabs assigned to the spawner.");
            return;
        }

        // Choose a random sprite prefab from the array
        int randomIndex = Random.Range(0, spritePrefabs.Length);
        GameObject chosenSpritePrefab = spritePrefabs[randomIndex];

        // Generate a random position within the defined spawn area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        float randomZ = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 randomSpawnPosition = new Vector3(randomX, randomY, randomZ);
        float randomAngle = Random.Range(0, 4) * 90f;

        Quaternion randomRotation = Quaternion.Euler(0f, randomAngle, 0f);

        // Instantiate the chosen sprite prefab at the random position
        Instantiate(chosenSpritePrefab, randomSpawnPosition, randomRotation);
    }
    void Start()
    {
        if (special != null)
            for (int i = 0; i < specialSpawnNumber; i++)
                SpawnRandomSprite();
    }

    // Example: Spawn a random sprite when the spacebar is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && special == null)
        {
            SpawnRandomSprite();
        }
    }
}
