using UnityEngine;
using UnityEngine.Events;

#region Input Events

public class MouseButtonDownInput : UnityEvent {

  public Vector2 Position { get { return position; } }
  private Vector2 position;

  public MouseButtonDownInput(Vector2 position) {
    this.position = position;
  }

}

#endregion