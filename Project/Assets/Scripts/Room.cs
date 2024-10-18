using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Create an Enemy List with all active enemies in the room
    // public List<Enemy> enemies = new List<Enemy>()
    public List<Door> Doors;

    private void Start()
    {
        // Close all doors
        foreach (Door door in Doors)
        {
            door.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        // If all enemies in the room have been defeated open the doors
        RoomCompleted();
    }

    private void RoomCompleted()
    {
        // ShowUpgrades()
        OpenDoors();
    }

    private void OpenDoors()
    {
        foreach (Door door in Doors)
        {
            door.gameObject.SetActive(false);
        }
    }
}
