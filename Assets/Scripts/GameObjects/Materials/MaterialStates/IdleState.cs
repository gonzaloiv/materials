using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MaterialStates {

  public class IdleState : BaseState {

    #region Fields

    private Tweener shaking;

    #endregion

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      if(shadowBehaviour != null)
        shadowBehaviour.enabled = false;
      shaking = transform.DOShakeScale(1f, 0.2f, 5, 180, true).SetEase(Ease.InOutBounce).SetLoops(-1).Pause();
      if(!shaking.IsPlaying())
        shaking.Play();
    }

    public override void Exit() {
      base.Exit();
      shaking.Rewind();
    }

    #endregion
   
  }

}