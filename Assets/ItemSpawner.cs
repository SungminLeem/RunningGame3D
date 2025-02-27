using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public Transform spawnArea;
    public int maxItems = 10;
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnItem();
            timer = 0f;
        }
    }

    void SpawnItem()
    {
        if (GameObject.FindGameObjectsWithTag("Item").Length >= maxItems)
            return;

        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.position.x - 5, spawnArea.position.x + 5),
            spawnArea.position.y,
            Random.Range(spawnArea.position.z - 5, spawnArea.position.z + 5)
        );

        int randomIndex = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomIndex], randomPosition, Quaternion.identity);
    }
}
