﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour, IPointerClickHandler {

  #region IPointerClickHandler

  public void OnPointerClick(PointerEventData pointerEventData) {    
    SceneManager.LoadScene(1);
  }

  #endregion
	
}
