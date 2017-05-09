using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GoalStates {

  public class IdleState : State {

    #region Fields

    private Tweener shaking;

    #endregion

    #region Mono Behaviour

    void Awake() {
      shaking = transform.DOShakeScale(1f, 0.2f, 5, 180, true).SetEase(Ease.InOutBounce).SetLoops(-1).Pause();
    }

    #endregion

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      if(!shaking.IsPlaying())
        shaking.Play();
    }

    public override void Exit() {
      base.Enter();
      shaking.Rewind();
    }

    #endregion
   
  }

}