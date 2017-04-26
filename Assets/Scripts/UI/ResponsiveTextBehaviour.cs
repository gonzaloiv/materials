using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ResponsiveTextBehaviour : MonoBehaviour {

  #region Fields

  private Text text;
  private Vector2 screenSize;

  private int initialFontSize;
  private Vector2 initialPosition;

  #endregion

  #region Mono Beheaviour

  void Awake() {
    screenSize = new Vector2(Screen.width, Screen.height);
    text = GetComponent<Text>();
    initialFontSize = text.fontSize;
    initialPosition = text.rectTransform.anchoredPosition;
  }

  void Start() {
    SetFontSize();
    SetPosition();
  }

  #endregion

  #region Private Behaviour

  private void SetFontSize() {
    text.fontSize = Mathf.RoundToInt(initialFontSize * screenSize.magnitude / Config.STANDARD_DEFINITION.magnitude);
  }

  private void SetPosition() {
    text.rectTransform.anchoredPosition = initialPosition * screenSize.magnitude / Config.STANDARD_DEFINITION.magnitude;
  }

  #endregion
	
}
