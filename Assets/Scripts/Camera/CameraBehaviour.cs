using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private CameraMovement initialMovement;
  [SerializeField] private CameraMovement goalMovement;
  [SerializeField] private CameraMovement selectionMovement;

  private CameraController cameraController;
  private int currentMovement = 0;

  #endregion

  #region Mono Behaviour

  void Awake() {
    cameraController = GetComponent<CameraController>();
  }

  void OnEnable() {
    EventManager.StartListening<LevelStartEvent>(OnLevelStartEvent);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StartListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
    EventManager.StartListening<GoalEvent>(OnGoalEvent);
    EventManager.StartListening<MaterialSelectionEvent>(OnMaterialSelectionEvent);
  }

  void OnDisable() {
    EventManager.StopListening<LevelStartEvent>(OnLevelStartEvent);
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StopListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
    EventManager.StopListening<GoalEvent>(OnGoalEvent);
    EventManager.StopListening<MaterialSelectionEvent>(OnMaterialSelectionEvent);
  }

  #endregion

  #region Event Behaviour

  void OnLevelStartEvent(LevelStartEvent levelStartEvent) {
    Move(initialMovement);
  }

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
  }

  void OnPlayerSelectionEvent(PlayerSelectionEvent playerSelectionEvent) {
    Move(selectionMovement);
  }

  void OnGoalEvent(GoalEvent goalEvent) {
    Move(goalMovement);
  }

  void OnMaterialSelectionEvent(MaterialSelectionEvent materialSelectionEvent) {}

  #endregion

  #region Private Behaviour

  private void Move(CameraMovement nextMove) {

    switch (nextMove.Type) {
      case CameraMovementType.Zoom:
        cameraController.UpdateSize(nextMove.Scale, nextMove.Speed);
        break;  
      case CameraMovementType.Reset:
        cameraController.ResetSize(nextMove.Speed);
        break;  
    }

  }

  #endregion

}