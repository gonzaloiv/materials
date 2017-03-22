using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

  #region Mono Behaviour

  void Update() {
    if (Input.GetMouseButtonDown(0))
      EventManager.TriggerEvent(new MouseButtonDownInput(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y))));
  }

  #endregion

}