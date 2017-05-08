using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

  #region Fields

  [SerializeField] private Vector2 direction = Vector2.zero;
  [SerializeField] private float force = 0f;

  public PlayerMovement PlayerMovement { get { return playerMovement; } }
  private PlayerMovement playerMovement;

  public bool IsLevelEnd { get { return isLevelEnd; } }
  [SerializeField] private bool isLevelEnd = false;

  public Vector2 Position { get { return position; } }
  private Vector2 position;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerMovement = new PlayerMovement(direction, force);
    position = transform.position;
  }

  #endregion

}
