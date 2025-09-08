using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    //canvas
    public int Lives;
    public int Score;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text scoreText;

    //spawning
    [SerializeField] private float spawnInterval;
    private float spawnTimer;
    [SerializeField] private GameObject normal;
    [SerializeField] private GameObject fast;
    [SerializeField] private GameObject slow;
    [SerializeField] private GameObject[] spawner;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shoot;

    private void Start()
    {
        Lives = 3;
    }

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

    public void PlayerHit()
    {
        Lives--;
        livesText.text = "Lives: " + Lives;
        audioSource.PlayOneShot(shoot);
        if (Lives == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void EnemyHit()
    {
        Score++;
        scoreText.text = "Score: " + Score;
        audioSource.PlayOneShot(shoot);
    }
}