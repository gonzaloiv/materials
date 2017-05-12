using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using MaterialStates;
using System.Linq;

public class DragableBehaviour : LeanSelectableBehaviour {

  #region Fields

  [SerializeField] private Vector2 minPosition;
  [SerializeField] private Vector2 maxPosition;

  private MaterialBehaviour materialBehaviour;
  private LeanSelectable leanSelectable;
  private Camera cam;

  #endregion

  #region Mono Behaviour

  void Awake() {
    materialBehaviour = GetComponent<MaterialBehaviour>();
    leanSelectable = GetComponent<LeanSelectable>();
  }

  void Update() {
    if (leanSelectable != null && leanSelectable.IsSelected != false) {
      List<LeanFinger> fingers = LeanTouch.GetFingers(true);
      Vector2 screenDelta = LeanGesture.GetScreenDelta(fingers);
      Translate(screenDelta);
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

  #region Private Behaviour

  private void Translate(Vector2 screenDelta) {
    if (LeanTouch.GetCamera(ref cam) == true) {
      Vector3 screenPosition = cam.WorldToScreenPoint(transform.position);
      screenPosition += (Vector3) screenDelta;
      screenPosition = cam.ScreenToWorldPoint(screenPosition);
      transform.position = ValidDragPosition(screenPosition);
    }
  }

  private Vector2 ValidDragPosition(Vector2 screenPosition) {

    if(minPosition.y == 0 && maxPosition.y == 0 && minPosition.x == 0 && maxPosition.x == 0) // FREE DRAG
      return transform.position;
      
    if (minPosition.y == 0 && maxPosition.y == 0) { // DRAG ON THE X AXIS
      if (transform.position.x > minPosition.x && screenPosition.x < transform.position.x)
        return new Vector2(screenPosition.x, transform.position.y);
      if (transform.position.x < maxPosition.x && screenPosition.x > transform.position.x)
        return new Vector2(screenPosition.x, transform.position.y);

    } else if (minPosition.x == 0 && maxPosition.x == 0) { // DRAG ON THE Y AXIS
      if (transform.position.y > minPosition.y && screenPosition.y < transform.position.y)
        return new Vector2(transform.position.x, screenPosition.y);
      if (transform.position.y < maxPosition.y && screenPosition.y > transform.position.y)
        return new Vector2(transform.position.x, screenPosition.y);
    }

    return transform.position; // FREE DRAG

  }

  #endregion

}