using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  [SerializeField] private Transform attackTransform;
  [SerializeField] private float attackrange = 1.5f;
  [SerializeField] private LayerMask attackableLayer;
  [SerializeField] private float damageAmount = 1f;

  public float Attackdelay = 0.3f;

  private RaycastHit2D[] hits;
 //Currently not in use
  /*void start() {

  }*/

  void Update () {
    if (UserInput.instance.Controls.AttackI.AttackI.WasPressedThisFrame()) {

    Invoke("Attack", Attackdelay);
    }
  }

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
