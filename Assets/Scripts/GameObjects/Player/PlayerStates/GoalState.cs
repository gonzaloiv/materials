using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace PlayerStates {

  public class GoalState : BaseState {

    #region Fields

    private static Vector2 goalPosition;

    #endregion

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      transform.DOMove(goalPosition, 2);
    }

    #endregion

    #region Public Behaviour

    public static void SetGoalPosition(Vector2 position) {
      goalPosition = position;
    }

    #endregion

  }

}