using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class PlayerSelectableBehaviour : LeanSelectableBehaviour {

  #region Fields

  private Player player;

  #endregion

  #region Mono Behaviour

  void Awake() {
    player = GetComponent<Player>();
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    player.IsSelected = !player.IsSelected;
    EventManager.TriggerEvent(new PlayerSelectionEvent());
  }

  #endregion

}
