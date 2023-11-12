using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidAnimation : MonoBehaviour
{
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
