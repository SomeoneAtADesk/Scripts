using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
// information about the player attack. it's important so it's private, but if you need to change it change it in the inspector.
  [SerializeField] private Transform attackTransform;
  [SerializeField] private float attackrange = 1.5f;
  [SerializeField] private LayerMask attackableLayer;
  [SerializeField] private float damageAmount = 1f;
// delay for the atack, preferably change in inspector
  public float Attackdelay = 0.5f;
// ANIMATION!!!
  public Animator anim;
// get raycast? idk raycast is confusing as fuck, sean is much better at it than me
  private RaycastHit2D[] hits;
 //Currently not in use
  /*void start() {

  }*/

  void Update () {
// if user presses the Attack button (set in the controls tab in unity) and the player isnt running, attack
    if (UserInput.instance.Controls.AttackI.AttackI.WasPressedThisFrame() && anim.GetBool("Running") == false) {

    Invoke("Attack", Attackdelay);
    }
  }
// Attack
  public void Attack() {
    //creating and Using the Attack Hitbox in front of the player, then checks if a object is on a attackable layer
    hits = Physics2D.CircleCastAll(attackTransform.position, attackrange, transform.right, 0f, attackableLayer);
    for (int i = 0; i < hits.Length; i++) {
      IDamageable iDamagable = hits[i].collider.gameObject.GetComponent<IDamageable>();

      if (iDamagable != null) {
        //apply damage
  
        iDamagable.Damage(damageAmount);
      }
    }
  }
  //Draws a visable circle of the attack hitbox in the scene
  private void OnDrawGizmosSelected() {
    Gizmos.DrawWireSphere(attackTransform.position, attackrange);
  }
}
