using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNpc : MonoBehaviour
{
    public static SpawnerNpc instance;

   public  GameObject characterPrefab; // Assign your character prefab in the Unity Editor
    
   public  Transform spawnPoint; // Assign your spawn point transform in the Unity Editor


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SpawnCharacters(6);
    }

    public  void SpawnCharacters( int character)
    {
        
        for (int i = 0; i < character; i++)
        {
            
            Vector3 spawnOffset = Random.insideUnitSphere * 2f;
            Vector3 spawnPosition = spawnPoint.position + spawnOffset;

            GameObject newCharacter = Instantiate(characterPrefab, spawnPosition, Quaternion.identity);
            
        }
    }
}

