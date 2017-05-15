using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  #region Fields

  private int currentLevel = 1;

  #endregion

  #region Mono Behaviour

  void Start() {
    EventManager.TriggerEvent(new LevelStartEvent());
  }

  void OnEnable() {
    EventManager.StartListening<LevelEndEvent>(OnLevelEndEvent);
  }

  void OnDisable() {
    EventManager.StopListening<LevelEndEvent>(OnLevelEndEvent);
  }

  #endregion

  #region Event Behaviour

  void OnLevelEndEvent(LevelEndEvent levelEndEvent) {
    SceneManager.LoadScene(currentLevel);
  }

  #endregion

}