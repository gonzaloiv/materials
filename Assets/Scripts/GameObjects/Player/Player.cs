using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public struct Player {

  #region Fields

  public static bool IsSelected { get { return isSelected; } set { isSelected = value; } }
  private static bool isSelected = false;

  public static PlayerMovement PlayerMovement { get { return playerMovement; } set { playerMovement = value; } }
  private static PlayerMovement playerMovement;

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