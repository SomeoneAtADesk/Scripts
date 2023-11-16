using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float initialSpeed = 1.0f; // Initial movement speed
    public float acceleration = 0.1f; // Rate of acceleration
    public float maxSpeed = 5.0f; // Maximum speed
    public float currentSpeed; // the speed the camera is going at the current time
    public bool DeathWallYes;
    public bool CameraStopYes;
    [HideInInspector] public bool DeathWallStop = false;
    [HideInInspector] public bool CameraStopStop = false;

    private PlayerHealth PD; // getting the player health component
    private EnemyHealth EH; // gettimg the enemy health component
    private float deathZoneDamageAmount = 3f; // Amount of damage the death zone does to asteroids, it instakills them

    void Start() {
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
      DeathWallStop = false;
      CameraStopStop = false;
    }

    void Update() {
// Increase the speed up to the maximum speed
    if (currentSpeed < maxSpeed) {
      currentSpeed += acceleration * Time.deltaTime;
      currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
    }
    if (DeathWallStop == true) {
      currentSpeed = 0;
    }
    if (CameraStopStop == true) {
      currentSpeed = 0;
    }
// Move the camera to the right
        Vector3 currentPosition = transform.position;
        transform.position = new Vector3(currentPosition.x + currentSpeed * Time.deltaTime, currentPosition.y, currentPosition.z);
    }
  // if the player hits the deathzone, and it is infact the player, then kill the player
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player") && PD != null) {
            Debug.Log("DeathZone");
            PD.PlayerDied();
        }

// IF an asteroid hits the deathzone, check if it in fact an asteroid, then kill the asteroid.
        if (col.gameObject.CompareTag("Asteroid")) {
            IDamageable iDamageable = col.gameObject.GetComponent<IDamageable>();

            if (iDamageable != null) {
// Apply damage using the IDamageable interface to kill the asteroids
                iDamageable.Damage(deathZoneDamageAmount);
            }
            else {
                Debug.LogWarning("Asteroid does not implement IDamageable or IDamageable component not found.");
            }
          }
        if (DeathWallYes = true) {
          if (col.gameObject.CompareTag("DeathWallStop")){
            DeathWallStop = true;
          }
        }
        if (CameraStopYes = true) {
          if (col.gameObject.CompareTag("CameraStop")) {
          CameraStopStop = true;
          }
        }
    }
}
