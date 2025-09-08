using UnityEngine;

public class KillboxController : MonoBehaviour
{
    private GameManager gm;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            gm.PlayerHit();
            Destroy(collision.gameObject);
        }
    }
}
