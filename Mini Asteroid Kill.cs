using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAsteroidKill : MonoBehaviour
{
  // set the time to kill the mini asteroids in the inspector
  [SerializeField] private float KillDelay;
    // Start is called before the first frame update
    void Start()  {
    // kill the mini asteroids after a short amount of time,
      Invoke("Death", KillDelay);
    }
    // mini asteroids are killed
    void Death() {
      Destroy(gameObject);
    }
}
