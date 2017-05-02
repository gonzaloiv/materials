using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoadBehaviour : MonoBehaviour, IPointerClickHandler {

  #region Fields

  [SerializeField] private int scene;

  #endregion

  #region IPointerClickHandler

  public void OnPointerClick(PointerEventData pointerEventData) {    
    SceneManager.LoadScene(scene);
  }

  #endregion
	
}
