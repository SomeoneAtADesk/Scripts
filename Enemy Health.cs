using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour, IDamageable
{
  [SerializeField] private float MaxHealth =3f;

  private float CurrentHealth;

  private void Awake() {
    CurrentHealth = MaxHealth;
  }
  public void Damage(float damageAmount) {
      CurrentHealth -= damageAmount;

      if (CurrentHealth <= 0) {
        Die();
      }
  }
  private void Die() {
    Destroy(gameObject);
    Scene.LoadScene (/*Name Of Sence*/);
    // Optimization Fix:
    // Have a prefab tied to the crystal objects in the scene which we can change the scene amount by x.
  }
}
