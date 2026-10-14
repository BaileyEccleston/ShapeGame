
using UnityEngine;

public class ShapeSpawner : MonoBehaviour
{
    [Header("Shape Prefabs")]
    [SerializeField] private GameObject[] shapePrefabs;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 2f;

    private float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnShape();
            spawnTimer = 0f;
        }
    }

    private void SpawnShape()
    {
        if (shapePrefabs == null || shapePrefabs.Length == 0)
            return;

        int randomIndex = Random.Range(0, shapePrefabs.Length);

        Instantiate(
            shapePrefabs[randomIndex],
            transform.position,
            Quaternion.identity
        );
    }
}
