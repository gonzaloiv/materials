using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class PlayerSelectableBehaviour : LeanSelectableBehaviour {

  #region Fields

  private PlayerController playerController;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerController = GetComponent<PlayerController>();
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    Player.IsSelected = !Player.IsSelected;
    EventManager.TriggerEvent(new PlayerSelectionEvent());
  }

  #endregion

}
