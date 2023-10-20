using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private RaycastHit2D[] hits;

    Animator anim;
    Rigidbody2D rb;

    public float PRIAnimation;

    float InputHorizontal;
    float InputVertical;
    bool facingright = true;
    bool Jump;
    void Start()  {
      anim = GetComponent<Animator>();
      rb = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()  {
      InputHorizontal = Input.GetAxis("Horizontal");
      if (InputHorizontal > 0 && !facingright) {
        Flip();
      }
      else if (InputHorizontal < 0 && facingright) {
        Flip();
      }
    }

    void Flip() {
      Vector3 currentScale = gameObject.transform.localScale;
      currentScale.x *= -1;
      gameObject.transform.localScale = currentScale;
      facingright = !facingright;
    }
}
