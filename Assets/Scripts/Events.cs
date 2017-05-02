using UnityEngine;
using UnityEngine.Events;

#region Game Mechanics Events

public class PlayerHitEvent : UnityEvent {
  public PlayerHitEvent() {
    Debug.Log("PlayerHitEvent");
  }
}

public class PlayerSelectionEvent : UnityEvent {
  public PlayerSelectionEvent() {
    Debug.Log("PlayerSelectionEvent");
  }
}

public class GoalEvent : UnityEvent {

  public bool IsLevelEnd { get { return isLevelEnd; } }
  private bool isLevelEnd;

  public GoalEvent(bool isLevelEnd) {
    this.isLevelEnd = isLevelEnd;
    Debug.Log("GoalEvent. IsLevelEnd: " + isLevelEnd);
  }

}

#endregion

#region Scene Management Events

public class LevelEndEvent : UnityEvent {
  public LevelEndEvent() {
    Debug.Log("LevelEndEvent");
  }
}

#endregion
