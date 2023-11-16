using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
  public void Damage(float damageAmount);
}
// call upon this to damage the enemy, otherwise it will damage a random object and not the correct one.
