using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaterialStates;

public class MaterialBehaviour : StateMachine {

  #region Mono Behaviour

  void Awake() {
    ChangeState<IdleState>();
  }

  #endregion

  #region Public Behaviour

  public void Close() {
    ChangeState<ActiveState>();
  }

  public void Activate() {
    if (CurrentState.GetType() == typeof(IdleState))
      ChangeState<ActiveState>();
    else if (CurrentState.GetType() == typeof(ActiveState))
      ChangeState<IdleState>();
  }

  #endregion

}
