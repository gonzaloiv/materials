using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Controller : MonoBehaviour {

	#region Fields
  #endregion

	#region Mono Behaviour

  void OnEnable() {
    EventManager.StartListening<MouseButtonDownInput>(OnMouseButtonDownInput);
  }

  void OnDestroy() {
    EventManager.StopListening<MouseButtonDownInput>(OnMouseButtonDownInput);
  }

	#endregion

  #region Event Behaviour

  void OnMouseButtonDownInput(MouseButtonDownInput mouseButtonDownInput) {
    Debug.Log("MouseButtonDownInput on " + mouseButtonDownInput.Position); 
  }

  #endregion

}
