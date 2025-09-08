using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float moveInput;

    [SerializeField] private bool shooting;
    [SerializeField] private float fireCooldown;
    private float fireRate;

    public GameObject Bullet;
    public GameObject Fire;

    //sounds
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shoot;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 5;
        fireRate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * moveInput * Time.deltaTime);

        if (fireRate <= 0 && shooting == true)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            Instantiate(Fire, transform.position, Quaternion.identity);
            audioSource.PlayOneShot(shoot);
            fireRate = fireCooldown;
        }

        if(fireRate > 0)
        {
            fireRate -= Time.deltaTime;
        }
    }

    private void OnMovement(InputValue direction)
    {
        moveInput = direction.Get<float>();
    }

    private void OnShoot(InputValue value)
    {
        shooting = value.isPressed;
    }
}
