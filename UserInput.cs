using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
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
