using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    public GameObject convertedCharacterPrefab; // Prefab to convert into after 10 seconds

    private NavMeshAgent navMeshAgent;
    private bool converted = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        GameObject nearestRoom = FindNearestRoom();
        if (nearestRoom != null && !nearestRoom.GetComponent<Room>().IsOccupied())
        {
            MoveToDestination(nearestRoom.transform);
            nearestRoom.GetComponent<Room>().SetOccupied(true);
        }
        else
        {
            Debug.LogError("No available room found!");
        }

        StartCoroutine(ConvertAfterDelay());
    }

    void MoveToDestination(Transform destination)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.SetDestination(destination.position);
        }
    }

    GameObject FindNearestRoom()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        GameObject nearestRoom = null;
        float shortestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject room in rooms)
        {
            float distanceToRoom = Vector3.Distance(currentPosition, room.transform.position);
            if (distanceToRoom < shortestDistance && !room.GetComponent<Room>().IsOccupied())
            {
                shortestDistance = distanceToRoom;
                nearestRoom = room;
            }
        }

        return nearestRoom;
    }

    IEnumerator ConvertAfterDelay()
    {
        yield return new WaitForSeconds(10f); // Wait for 10 seconds

        if (!converted)
        {
            ConvertCharacter();
        }
    }

    void ConvertCharacter()
    {
        // Find the room the character was occupying
        GameObject room = FindOccupiedRoom();

        // If a room was found and it has the Room component, unoccupy it
        if (room != null && room.GetComponent<Room>() != null)
        {
            room.GetComponent<Room>().SetOccupied(false);
        }

        // Destroy the initial character
        Destroy(gameObject);

        // Instantiate the converted character
        Instantiate(convertedCharacterPrefab, transform.position, transform.rotation);

        // Set converted flag to true
        converted = true;

        // Spawn new characters
        SpawnerNpc.instance.SpawnCharacters(1);
    }

    GameObject FindOccupiedRoom()
    {
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject room in rooms)
        {
            if (room.GetComponent<Room>() != null && room.GetComponent<Room>().IsOccupied())
            {
                return room;
            }
        }
        return null;
    }

}

