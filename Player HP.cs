using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  // max player hp, dont change
    public int maxHealth = 100;
  // current hp used to kill the player and heal and stuff
    public int currentHealth;
  // ANIMATION!!!
    public Animator anim;
  // reset the scene to the current scene you are on. helpful for the levels. You don't need to change it. its calling upon a different script though.
    public SceneReset SceneReset;
    private SceneReset SR;

    void Start()  {
// Initialize the player's current health to the maximum health when the game starts.
        currentHealth = maxHealth;
// Get the animator for the death animation
        anim = GetComponent<Animator>();
// Get the scene reload script so that the scene can reload when the player DistortedPixelStudios
        SR = GetComponent<SceneReset>();
    }
// Method to apply damage to the player
    public void TakeDamage(int damage)  {
        currentHealth -= damage;
// Check if the player's health has reached zero or below.
        if (currentHealth <= 0)
        {
// Play Player Death animation
          anim.SetBool("PDeath", true);
// Player has died. Implement game over or respawn logic here.
          Invoke("PlayerDied", 1f);
        }
    }

    public void PlayerDied() {
        // Reset the scene so that the player can restart
        SceneReset.ResetCurrentScene(); // Call this from another script to reset the scene
    }
}
