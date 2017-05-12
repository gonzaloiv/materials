using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using MaterialStates;

public class ScalableBehaviour : LeanSelectableBehaviour {

  #region Fields

  [SerializeField] private float SCALE_RATIO = 1000f;

  [SerializeField] private float minScale;
  [SerializeField] private float maxScale;

  private MaterialBehaviour materialBehaviour;
  private LeanSelectable leanSelectable;
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
      float scale = LeanGesture.GetPinchScale(fingers, 100);
//      scale = (scale - 1) * SCALE_RATIO;
      Debug.Log("SCALE1 " + scale);
      Vector2 nextScale = initialScale * scale;
      if (scale != 1 && nextScale.x <= initialScale.x * maxScale && nextScale.x >= initialScale.x * minScale) {
        Debug.Log("SCALE " + scale);
//        transform.localScale = Vector2.Lerp(transform.localScale, initialScale * scale, 10);
        transform.localScale = nextScale;
      }
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