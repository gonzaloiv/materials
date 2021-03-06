﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates {

  public class ActiveState : BaseState {

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      playerController.ResetRigidbody();
      rb.AddForce(player.PlayerMovement.Direction * player.PlayerMovement.Force, ForceMode2D.Impulse);
    }

    public override void Exit() {
      base.Exit();
      playerController.ResetRigidbody();
    }

    #endregion

  }

}