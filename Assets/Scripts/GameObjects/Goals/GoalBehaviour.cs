using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using GoalStates;

public class GoalBehaviour : StateMachine {

  #region Fields

  private const float TRIGGER_TIME = 2f;
  private Goal goal;

  private bool active;
  private float timestamp;

  #endregion

  #region Mono Behaviour

  void Awake() {
    goal = GetComponent<Goal>();
    ChangeState<IdleState>();
  }

  void OnEnable() {
    timestamp = Time.time;
  }

  void OnTriggerEnter2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Player && timestamp + TRIGGER_TIME < Time.time) {
      ChangeState<InactiveState>();
      EventManager.TriggerEvent(new GoalEvent(goal));
    }
  }

  void OnTriggerExit2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Player)
      ChangeState<IdleState>();
  }

  #endregion
	
}