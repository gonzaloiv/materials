using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using MaterialStates;
using System.Linq;

public class DragableBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private Vector2 minPosition;
  [SerializeField] private Vector2 maxPosition;

  private MaterialBehaviour materialBehaviour;
  private LeanSelectable leanSelectable;
  private Camera camera;

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

  #region Private Behaviour

  private void Translate(Vector2 screenDelta) {
    if (LeanTouch.GetCamera(ref camera) == true) {
      Debug.Log("DELTA " + camera.ScreenToWorldPoint((Vector3) screenDelta));
      Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);
      screenPosition += (Vector3) screenDelta;
      screenPosition = camera.ScreenToWorldPoint(screenPosition);
      Debug.Log("ScreenPosition " + screenPosition);
      transform.position = ValidDragPosition(screenPosition);
    }
  }

  private Vector2 ValidDragPosition(Vector2 screenPosition) {
    Vector2 nextPosition = new Vector2(transform.position.x + Mathf.Sign(screenPosition.x) * 0.001f, transform.position.y + Mathf.Sign(screenPosition.y) * 0.001f);
    if (minPosition.y == 0 && maxPosition.y == 0) {
      if (transform.position.x > minPosition.x && screenPosition.x < transform.position.x)
        return new Vector2(screenPosition.x, transform.position.y);
      if (transform.position.x < maxPosition.x && screenPosition.x > transform.position.x)
        return new Vector2(screenPosition.x, transform.position.y);
    } else if (minPosition.x == 0 && maxPosition.x == 0) {
      if (transform.position.y > minPosition.y && screenPosition.y < transform.position.y)
        return new Vector2(transform.position.x, screenPosition.y);
      if (transform.position.y < maxPosition.y && screenPosition.y > transform.position.y)
        return new Vector2(transform.position.x, screenPosition.y);
    } else if (transform.position.x > minPosition.x && transform.position.x < maxPosition.x && transform.position.y > minPosition.y && transform.position.y <= maxPosition.y) {
      return new Vector2(screenPosition.x, screenPosition.y);
    }
    return transform.position;
  }

  #endregion

}