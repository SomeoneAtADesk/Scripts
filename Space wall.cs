using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spacewall : MonoBehaviour
{
  private PlayerHealth PD; // Declare PD variable
  private EnemyHealth EH;  // Declare EH variable
  private float OutOfBoundsDamageAmount = 3f;

    // Start is called before the first frame update
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
// if player collide with the space wall of death, kill the player, and thus reset the scene
    private void OnTriggerEnter2D(Collider2D col) {
      if (col.gameObject.CompareTag("Player") && PD != null)
      {
          Debug.Log("OutOfBounds");
          PD.PlayerDied();
      }

// Check if the trigger is an "Asteroid"
      if (col.gameObject.CompareTag("Asteroid")) {
        IDamageable iDamageable = col.gameObject.GetComponent<IDamageable>();
        if (iDamageable != null) {
// Apply damage using the IDamageable interface, so that it kills the asteroids
          iDamageable.Damage(OutOfBoundsDamageAmount);
        }
        else {
          // "uh oh" thats not good it this happens.
          Debug.LogWarning("Asteroid does not implement IDamageable or IDamageable component not found.");
        }
      }
   }
}
