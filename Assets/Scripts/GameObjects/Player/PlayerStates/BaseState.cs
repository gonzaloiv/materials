using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates {

  public class BaseState : State {

    #region Fields

    protected PlayerController playerController;
    protected Rigidbody2D rb;

    #endregion

    #region Mono Behaviour

    void Awake() {
      playerController = GetComponent<PlayerController>();
      rb = GetComponent<Rigidbody2D>();
    }

    #endregion

  }

}