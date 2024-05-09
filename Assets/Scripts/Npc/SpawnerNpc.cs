using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNpc : MonoBehaviour
{
    public static SpawnerNpc instance;

    public GameObject characterPrefab; // Assign your character prefab in the Unity Editor

    public Transform spawnPoint; // Assign your spawn point transform in the Unity Editor

    private int characterCount = 5; // Number of characters to spawn
    private float spawnDelay = 1.0f; // Delay between spawns

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnCharacters(characterCount);
    }

    


    public void  SpawnCharacters(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 spawnOffset = Random.insideUnitSphere * 2f;
            Vector3 spawnPosition = spawnPoint.position + spawnOffset;

            GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);

           
        }
    }
}
