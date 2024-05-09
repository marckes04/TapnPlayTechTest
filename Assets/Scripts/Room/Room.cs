using UnityEngine;

public class Room : MonoBehaviour
{
    private bool occupied = false;

    public bool IsOccupied()
    {
        return occupied;
    }

    public void SetOccupied(bool value)
    {
        occupied = value;
    }
}
