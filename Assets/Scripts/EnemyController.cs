using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int EnemyType;
    public int health;

    private GameManager gm;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();

        switch (EnemyType)
        {
            case 1:
                health = 2;
                break;

            case 2:
                health = 3;
                break;

            case 3:
                health = 1;
                break;
        }
    }

    void Update()
    {
        switch (EnemyType) {
            case 1:
                transform.Translate(Vector2.left * 1 * Time.deltaTime);
                break;

            case 2:
                transform.Translate(Vector2.left * 0.5f * Time.deltaTime);
                break;

            case 3:
                transform.Translate(Vector2.left * 2 * Time.deltaTime);
                break;
        }

        if(health <= 0)
        {
            Destroy(gameObject);
            gm.EnemyHit();
        }
    }
}
