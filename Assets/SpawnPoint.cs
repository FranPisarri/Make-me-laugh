using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void SetSpawnPoint()
    {
        Inventory.Instance.spawnCoordinates = new Vector3(-15, 10, 0);
    }
}
