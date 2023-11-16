using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTracker : MonoBehaviour
{
  private static SceneTracker instance;
  // What levels have already been completed to delete their crystak is it failed to die.
    public bool Space = false;
    public bool Jungle = false;
    public bool Snow = false;
    public bool Fire = false;
  void Awake() {
// Check if an instance already exists
    if (instance == null) {
// If no instance exists, set this as the instance and prevent it from being destroyed when loading new scenes
      instance = this;
      DontDestroyOnLoad(this.gameObject);

    } else {
// If an instance already exists, destroy the duplicate instance
    Destroy(gameObject);
    }
  }
  void start() {

  }
  void update() {

  }
}
