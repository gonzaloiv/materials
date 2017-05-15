using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using MaterialStates;

public class ScalableBehaviour : LeanSelectableBehaviour {

  #region Fields

  [SerializeField] private float SCALE_RATIO = 1.1f;
  [SerializeField] private float minScale;
  [SerializeField] private float maxScale;

  private MaterialBehaviour materialBehaviour;
  private LeanSelectable leanSelectable;
  private Camera cam;

  private Vector2 initialScale;

  #endregion

  #region Mono Behaviour

  void Awake() {
    materialBehaviour = GetComponent<MaterialBehaviour>();
    leanSelectable = GetComponent<LeanSelectable>();
    initialScale = transform.localScale;
  }

  void FixedUpdate() {
    if (leanSelectable != null && leanSelectable.IsSelected != false) {
      List<LeanFinger> fingers = LeanTouch.GetFingers(true);
      float scale = LeanGesture.GetPinchScale(fingers, 0);
      Vector2 nextScale = transform.localScale * scale;
      if(nextScale.x < initialScale.x * maxScale && nextScale.x > initialScale.x * minScale)
        transform.localScale = nextScale * SCALE_RATIO;
    }
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    materialBehaviour.Activate();
    EventManager.TriggerEvent(new MaterialSelectionEvent());
  }

  protected override void OnSelectUp(LeanFinger finger) {
    materialBehaviour.Activate();
  }

  #endregion

}