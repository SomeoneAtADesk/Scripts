using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float initialSpeed = 1.0f; // Initial movement speed
    public float acceleration = 0.1f; // Rate of acceleration
    public float maxSpeed = 5.0f; // Maximum speed

    private PlayerHealth PD;
    private EnemyHealth EH;
    private float currentSpeed;
    private float deathZoneDamageAmount = 3f;

    void Start()
    {
      // Find the PlayerHealth script in the scene
      PD = FindObjectOfType<PlayerHealth>();
      // Find the Enemy Health Script
      EH = FindObjectOfType<EnemyHealth>();
      // If Player Health isn't found
      if (PD == null) {
        Debug.LogError("PlayerHealth script not found in the scene.");
      }
      // if Enemy Health isn't found
      if (EH == null) {
        Debug.LogError("EnemyHealth script not found in the scene");
      }
    }

    void Update()
    {
// Increase the speed up to the maximum speed
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }

// Move the camera to the right
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x + currentSpeed * Time.deltaTime, currentPosition.y, currentPosition.z);
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player") && PD != null)
        {
            Debug.Log("DeathZone");
            PD.PlayerDied();
        }

// Check if the trigger is an "Asteroid"
        if (col.gameObject.CompareTag("Asteroid"))
        {
            IDamageable iDamageable = col.gameObject.GetComponent<IDamageable>();

            if (iDamageable != null)
            {
// Apply damage using the IDamageable interface
                iDamageable.Damage(deathZoneDamageAmount);
            }
            else
            {
                Debug.LogWarning("Asteroid does not implement IDamageable or IDamageable component not found.");
            }
        }
    }
}
