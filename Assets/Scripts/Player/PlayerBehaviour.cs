﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerStates;
using DG.Tweening;

public class PlayerBehaviour : StateMachine {

  #region Fields

  private const float TRIGGER_TIME = 0.2f; 
  private PlayerController playerController;
  private float timestamp;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerController = GetComponent<PlayerController>();
    ChangeState<IdleState>();
    timestamp = Time.time;
  }

  void OnEnable() {
    EventManager.StartListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
  }

  void OnTriggerEnter2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Goal && CurrentState.GetType() != typeof(GoalState) && timestamp + TRIGGER_TIME < Time.time) {
      GoalState.SetGoalPosition(collider2D.transform.position);
      ChangeState<GoalState>();
    }
  }

  void OnBecameInvisible() {
    playerController.Reset();;
    ChangeState<IdleState>();
  }

  #endregion

  #region Mono Behaviour

  void OnPlayerSelectionEvent(PlayerSelectionEvent playerSelectionEvent) {
    if (CurrentState.GetType() != typeof(ActiveState))
      ChangeState<ActiveState>();
    else
      ChangeState<IdleState>();
  }

  #endregion
	
}
