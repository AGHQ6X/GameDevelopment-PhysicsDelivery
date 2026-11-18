using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform spawnPoint;

    public void SpawnObject()
    {
        Instantiate(
            objectPrefab,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }
}