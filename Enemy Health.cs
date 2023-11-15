using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable

{
  private SceneTracker ST; // getting the SceneTracker component

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

// Lobby Crystals to their respected level
  public bool PurpleCrystal; // Hub
  public bool RedCrystal; // Hub
  public bool WhiteCrystal; // Hub
  public bool GreenCrystal; // Hub

// what to kill
  public bool PurpleKill; // Hub
  public bool RedKill; // Hub
  public bool WhiteKill; // Hub
  public bool GreenKill; // Hub

// Level Crystals Back to the lobby
  public bool PurpleCrystalHub; // Level
  public bool RedCrystalHub; // Level
  public bool WhiteCrystalHub; // Level
  public bool GreenCrystalHub; // Level

  private void Awake() {
    CurrentHealth = MaxHealth;
  }
  private void Start() {
// Find the SceneTracker script in the scene
    ST = FindObjectOfType<SceneTracker>().GetComponent<SceneTracker>();
// Kills the Space crystal after the Space level has been complete
    if (ST.Space == true && PurpleKill) {
      Die();
    }
// Kills the Green Crystal after the junge level has been complete
    if (ST.Jungle == true && GreenKill) {
      Die();
    }
// Kills the White crystal after the Snow level has been complete
    if (ST.Snow == true && WhiteKill) {
      Die();
    }
// Kills the Red crystal after hte volcano level has been complete
    if (ST.Fire == true && RedKill) {
      Die();
    }
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
// Explosion 2, triggering when both the bool is checked as yes in the inspector and a bullet is put in bullet 2 slot in the inspector (Bullet being a prefab)
        if(doesExplode2) {
          Explode2();
        }
// load the corrent scene based on a bool secelcted in the inspector. Correct scene being Dependent on Which crystal you destory as long as it has the corrent bool checked.
        if (PurpleCrystal) {
          LoadSceneSpace();
        }
        if (RedCrystal) {
          LoadSceneVolcano();
        }
        if (WhiteCrystal) {
          LoadSceneSnow();
        }
        if (GreenCrystal) {
          LoadSceneJungle();
        }
// From space level back to hub, changing a bool marking the level as complete
        if (PurpleCrystalHub) {
          ST.Space = true;
          LoadScene();
        }
        if (RedCrystalHub) {
          ST.Fire = true;
          LoadScene();
        }
        if (WhiteCrystalHub) {
          ST.Snow = true;
          LoadScene();
        }
        if (GreenCrystalHub) {
          ST.Jungle = true;
          LoadScene();
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
// Load a specific scene if the correct function is called
  private void LoadScene() {
     SceneManager.LoadScene("0. Lobby");
  }
  private void LoadSceneJungle() {
    SceneManager.LoadScene("1. Weed");
  }
   private void LoadSceneSpace() {
      SceneManager.LoadScene("2. Space");
   }
   private void LoadSceneVolcano() {
    SceneManager.LoadScene("3. Lava");
  }
  private void LoadSceneSnow() {
    SceneManager.LoadScene("4. Snow");
  }
}
