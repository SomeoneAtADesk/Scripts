using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAnimation : MonoBehaviour
{
  // I tried and faile to make an asteroid being attacked animation, probably could have gotten it to work, but not worth the time
  public Animator anim;
  private EnemyHealth hp;
  
  void Start() {
    anim = GetComponent<Animator>();
    hp = GetComponent<EnemyHealth>();
  }
  void update() {
    anim.SetFloat("AHP", + hp.CurrentHealth - 0.1f);
  }
}
