using UnityEngine;

public class PlatformAnimation : MonoBehaviour
{

//  ParticleSystem particles;
  Animator anim;
    void Start() {
    //  particles = GetComponent<ParticleSystem>();
      anim = GetComponent<Animator>();
    }
    /*void Update() {

    }*/

    void OnTriggerEnter2D (Collider2D col) {
    //  particles.Play();
      anim.Play("MPA");
    }
    void OnTriggerExit2D (Collider2D col) {
    //  particles.Stop();
      anim.Play("PIdle");
    }

}
