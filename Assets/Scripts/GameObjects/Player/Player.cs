using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour {

  #region Fields

  [SerializeField] private Vector2 direction;
  [SerializeField] private float force;

  public bool IsSelected { get { return isSelected; } set { isSelected = value; } }
  private bool isSelected = false;

  public PlayerMovement PlayerMovement { get { return playerMovement; } set { playerMovement = value; } }
  private PlayerMovement playerMovement;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerMovement = new PlayerMovement(direction, force);
  }

  void OnEnable() {
    EventManager.StartListening<GoalEvent>(OnGoalEvent);
  }

  void OnDisable() {
    EventManager.StartListening<GoalEvent>(OnGoalEvent);
  }

  #endregion

  #region Event Behaviour

  void OnGoalEvent(GoalEvent goalEvent) {
    this.playerMovement = goalEvent.Goal.PlayerMovement;
  }

  #endregion

  #region Public Behaviour

  public void Reset() {
    this.playerMovement = new PlayerMovement(direction, force);
    this.isSelected = false;
  }

  #endregion

}

public struct PlayerMovement {

  public Vector2 Direction { get { return direction; } }
  private Vector2 direction;

  public float Force { get { return force; } }
  private float force;

  public PlayerMovement(Vector2 direction, float force) {
    this.direction = direction;
    this.force = force;
  }

}