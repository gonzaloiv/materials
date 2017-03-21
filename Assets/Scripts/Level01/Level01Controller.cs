using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01Controller : MonoBehaviour {

	#region Fields

  Timer timer;

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
    if(timer != null && !timer.isDone)
      Timer.Pause(timer);
    timer = Timer.Register(1f, () => Debug.Log("MouseButtonDownInput on " + mouseButtonDownInput.Position), isLooped: true);
  }

  #endregion

}
