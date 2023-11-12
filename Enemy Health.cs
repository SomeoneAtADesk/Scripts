using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable

{
  // max health, customise in inspector on the object, not here.
  [SerializeField] private float MaxHealth =3f;
  // the health that the game uses to determine when the enemy is dead
  public float CurrentHealth;
  // setable objects in inspetor so that you can makes the enemy explode into whatever you set it to explode into
  public GameObject bullet;
  public GameObject bullet2;
  // the bool you set if you want it to explode, to explode you need both a bullet for the correct explosion and the bool set to true.
  public bool doesExplode1;
  public bool doesExplode2;

  private void Awake() {
    CurrentHealth = MaxHealth;
  }
  // to call upon the damage variable you need to use iDamageable to damage the enemy
  public void Damage(float damageAmount) {
      CurrentHealth -= damageAmount;
    if (CurrentHealth <= 0) {
        Die();
        // explosion of the enemy while it dies, using the bullet game objects, which are just prefabs you can set.
        if(doesExplode1) {
          Explode();
        }
        if(doesExplode2) {
          Explode2();
        }

      }
  }
  // Function: enemy dies is they are killed
  private void Die() {
    Destroy(gameObject);
  }

  // Function for the explosion
  public void Explode(){
    for(int i = 0; i < 25; i++) {
      Vector3 rot = new Vector3(0.0f, 0.0f, Random.Range(-360, 360));
      GameObject b = Instantiate(bullet, transform.position, Quaternion.Euler(rot));
      b.GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.Range(-50, 50), Random.Range(-50, 50));
    }
  }
  public void Explode2(){
    for(int i = 0; i < 25; i++) {
      Vector3 rot = new Vector3(0.0f, 0.0f, Random.Range(-360, 360));
      GameObject b = Instantiate(bullet2, transform.position, Quaternion.Euler(rot));
      b.GetComponent<Rigidbody2D>().velocity = new Vector2 (Random.Range(-50, 50), Random.Range(-50, 50));
    }
  }

}
