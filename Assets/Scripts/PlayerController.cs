using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float moveInput;

    private bool shooting;
    [SerializeField] private float fireCooldown;
    private float fireRate;

    public GameObject Bullet;
    public GameObject Fire;
    
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
            Instantiate(Bullet, this.transform);
            Instantiate(Fire, this.transform);
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

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            shooting = true;
        }

        if (context.canceled)
        {
            shooting = false;
        }
    }
}
