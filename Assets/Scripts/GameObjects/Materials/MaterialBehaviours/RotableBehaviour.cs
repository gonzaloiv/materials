using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using MaterialStates;

public class RotableBehaviour : LeanSelectableBehaviour {

  #region Fields

  [SerializeField] private float ROTATION_RATIO = 1f;

  [SerializeField] private float minRotation;
  [SerializeField] private float maxRotation;

  private MaterialBehaviour materialBehaviour;
  private LeanSelectable leanSelectable;
  private float initialRotation;

  #endregion

  #region Mono Behaviour

  void Awake() {
    materialBehaviour = GetComponent<MaterialBehaviour>();
    leanSelectable = GetComponent<LeanSelectable>();
    initialRotation = transform.eulerAngles.z;
  }

  void FixedUpdate() {
    if (leanSelectable != null && leanSelectable.IsSelected == true) {
      List<LeanFinger> fingers = LeanTouch.GetFingers(true);
      float degrees = LeanGesture.GetTwistDegrees(fingers) * ROTATION_RATIO;
      float currentRotation = Mathf.Abs(initialRotation - transform.eulerAngles.z);
      if(currentRotation + degrees >= 360 + minRotation || currentRotation + degrees <= maxRotation)
        transform.rotation *= Quaternion.AngleAxis(degrees, transform.forward); // forward for z-axis rotation
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