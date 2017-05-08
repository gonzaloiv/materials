using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStates {

  public class LevelEndState : BaseState {

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      GetComponent<PlayerSelectableBehaviour>().enabled = false;
    }

    public override void Exit() {
      base.Exit();
      GetComponent<PlayerSelectableBehaviour>().enabled = true;
    }

    #endregion

  }

}