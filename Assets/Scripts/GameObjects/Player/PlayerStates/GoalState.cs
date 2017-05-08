using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PlayerStates {

  public class GoalState : BaseState {

    #region Fields

    private static Goal currentGoal;

    #endregion

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      transform.DOMove(currentGoal.Position, 2);
      if(currentGoal.IsLevelEnd)
        GetComponent<PlayerSelectableBehaviour>().enabled = false;
    }

    public override void Exit() {
      base.Exit();
      if(currentGoal.IsLevelEnd)
        GetComponent<PlayerSelectableBehaviour>().enabled = true;
    }

    #endregion

    #region Public Behaviour

    public static void SetCurrentGoal(Goal goal) {
      currentGoal = goal;
    }

    #endregion

  }

}