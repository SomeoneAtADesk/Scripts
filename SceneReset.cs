using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
// Create a static method for resetting the scene
    public static void ResetCurrentScene() {
// Get the currently active scene
        Scene currentScene = SceneManager.GetActiveScene();
// Reload the active scene
        SceneManager.LoadScene(currentScene.name);
    }
}
