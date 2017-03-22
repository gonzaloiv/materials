using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Prime31.TransitionKit;

public class TitleController : MonoBehaviour, IPointerClickHandler {

  #region IPointerClickHandler implementation

  public void OnPointerClick(PointerEventData pointerEventData) {    

//    var fader = new FadeTransition() {
//      nextScene = 1,
//      fadeToColor = Color.white
//    };
//    TransitionKit.instance.transitionWithDelegate(fader);

    SceneManager.LoadScene(1);

  }

  #endregion
	
}
