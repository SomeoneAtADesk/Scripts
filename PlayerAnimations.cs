using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private RaycastHit2D[] hits;
  // Getting the animation and rigid body components
    Animator anim;
    Rigidbody2D rb;

  // getting the direction the player is facing
    float InputHorizontal;
    float InputVertical;
  // is the player facing right? yes, at least at the start. it will change and you don't need to do anything
    bool facingright = true;
  // it's something, might be used in another script so probably dont delete is just in case, but, uhhh, no idea whats it might be for.
    bool Jump;


    void Start()  {
  // finish getting the components
      anim = GetComponent<Animator>();
      rb = gameObject.GetComponent<Rigidbody2D>();
    }

  // check what direction the player is facng, is facing the direction the player isnt facing, cal upon the flip function
    void Update()  {
      InputHorizontal = Input.GetAxis("Horizontal");
      if (InputHorizontal > 0 && !facingright) {
        Flip();
      }
      else if (InputHorizontal < 0 && facingright) {
        Flip();
      }
    }
  // flip the direction the character is facing.
    void Flip() {
      Vector3 currentScale = gameObject.transform.localScale;
      currentScale.x *= -1;
      gameObject.transform.localScale = currentScale;
      facingright = !facingright;
    }
}
