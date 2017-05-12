using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MaterialStates {

  public class ActiveState : BaseState {

    #region Mono Behaviour

    private Tweener shaking;

    #endregion

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      DOTween.PauseAll();
      shadowBehaviour.enabled = true;
    }

    public override void Exit() {
      base.Exit();
      shadowBehaviour.enabled = false;
    }

    #endregion
   
  }

}

