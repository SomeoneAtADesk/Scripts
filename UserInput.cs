using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
  // No idea what this does, this was from one of the totorials
  // I beleive that this is used to get the controlls for movement
  public static UserInput instance;

  [HideInInspector] public Controls Controls;

    private void Awake()  {
      if (instance == null) {
        instance = this;
      }
        Controls = new Controls();
    }

    private void OnEnable()  {
        Controls.Enable();
    }
    private void OnDisable() {
      Controls.Disable();
    }
}
