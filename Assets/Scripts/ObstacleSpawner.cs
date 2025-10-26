using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform player;
    public float spawnInterval = 2f;
    public float spawnDistance = 50f;
    public float laneDistance = 3f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            int lane = Random.Range(0, 3);
            float xPos = (lane - 1) * laneDistance;

            Vector3 spawnPos = new Vector3(xPos, 0.5f, player.position.z + spawnDistance);
            Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
        }
    }
}
