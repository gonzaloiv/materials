using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;

public class PlayerBehaviour : StateMachine {

  #region Fields

  private PlayerController playerController;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerController = GetComponent<PlayerController>();
    ChangeState<IdleState>();
  }

  void OnEnable() {
    EventManager.StartListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
  }

  void OnTriggerEnter2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Goal) {
      Goal currentGoal = collider2D.gameObject.GetComponent<Goal>();
      if (CurrentState.GetType() != typeof(GoalState)) {
        GoalState.SetCurrentGoal(currentGoal);
        ChangeState<GoalState>();
      }
    }
  }

  void OnBecameInvisible() {
    playerController.Reset();
    ChangeState<IdleState>();
//    EventManager.TriggerEvent(new LevelEndEvent()); // TODO: a end-of-level state for the levels ending
  }

  #endregion

  #region Event Behaviour

  void OnPlayerSelectionEvent(PlayerSelectionEvent playerSelectionEvent) {
    if (CurrentState.GetType() != typeof(ActiveState))
      ChangeState<ActiveState>();
    else
      ChangeState<IdleState>();
  }

  #endregion
	
}