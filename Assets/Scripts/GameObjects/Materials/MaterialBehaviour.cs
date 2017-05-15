using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaterialStates;
using Lean.Touch;

public class MaterialBehaviour : StateMachine {

  #region Mono Behaviour

  void Awake() {
    ChangeState<IdleState>();
  }

  void OnEnable() {
    EventManager.StartListening<LevelRestartEvent>(OnLevelRestartEvent);
  }

  void OnDisable() {
    EventManager.StopListening<LevelRestartEvent>(OnLevelRestartEvent);
  }

  #endregion

  #region Event Behaviour

  void OnLevelRestartEvent(LevelRestartEvent levelRestartEvent) {
    LeanSelectable selectable = GetComponent<LeanSelectable>();
    if(selectable != null)
      selectable.Deselect();
  }

  #endregion

  #region Public Behaviour

  public void Close() {
    ChangeState<ClosedState>();
  }

  public void Activate() {
    if (CurrentState.GetType() == typeof(IdleState))
      ChangeState<ActiveState>();
    else if (CurrentState.GetType() == typeof(ActiveState))
      ChangeState<IdleState>();
  }

  #endregion

}
