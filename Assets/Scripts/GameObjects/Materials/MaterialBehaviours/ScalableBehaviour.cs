using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using MaterialStates;

public class ScalableBehaviour : LeanSelectableBehaviour {

  #region Fields

  private MaterialBehaviour materialBehaviour;

  #endregion

  #region Mono Behaviour

  void Awake() {
    materialBehaviour = GetComponent<MaterialBehaviour>();
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    materialBehaviour.Close();
    EventManager.TriggerEvent(new MaterialSelectionEvent());
  }

  #endregion

}