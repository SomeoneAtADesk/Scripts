using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
  }
}
