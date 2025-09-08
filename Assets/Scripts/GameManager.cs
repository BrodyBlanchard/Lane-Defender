using UnityEngine;

public class GameManager : MonoBehaviour
{
    //

    //spawning
    [SerializeField] private float spawnInterval;
    private float spawnTimer;
    [SerializeField] private GameObject normal;
    [SerializeField] private GameObject fast;
    [SerializeField] private GameObject slow;
    [SerializeField] private GameObject[] spawner;

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer <= 0)
        {
            spawnTimer = spawnInterval;
            Spawn(Random.Range(1,4));
        }

        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void Spawn(int value)
    {
        switch (value)
        {
            case 1:
                Instantiate(normal, spawner[Random.Range(0, 5)].transform);
                break;

            case 2:
                Instantiate(slow, spawner[Random.Range(0, 5)].transform);
                break;

            case 3:
                Instantiate(fast, spawner[Random.Range(0, 5)].transform);
                break;
        }
    }
}