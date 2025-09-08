using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private GameObject fire;

    void Update()
    {
        transform.Translate(Vector2.right * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            collision.gameObject.GetComponent<EnemyController>().health--;
            Instantiate(fire, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
