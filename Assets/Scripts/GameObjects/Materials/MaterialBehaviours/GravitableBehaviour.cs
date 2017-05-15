using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using MaterialStates;

public class GravitableBehaviour : LeanSelectableBehaviour {

  #region Fields

  [SerializeField] private float PULL_FORCE = 500;
  [SerializeField] private float PUSH_FORCE_RATIO = 10;
  [SerializeField] private GameObject player;

  private MaterialBehaviour materialBehaviour;
  private bool selected = false;
  private Vector2 forceDirection;

  #endregion

  #region Mono Behaviour

  void Awake() {
    materialBehaviour = GetComponent<MaterialBehaviour>();
  }

  void Update() {
    if (selected) {
      forceDirection = (Vector2) transform.position - (Vector2) player.transform.position;
      player.GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * PULL_FORCE);
    }
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    materialBehaviour.Activate();
    selected = !selected;
    if(!selected)
      player.GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * PULL_FORCE * PUSH_FORCE_RATIO);
    EventManager.TriggerEvent(new MaterialSelectionEvent());
  }

  #endregion

}