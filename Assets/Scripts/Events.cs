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
  public GoalEvent() {
    Debug.Log("GoalEvent");
  }
}

#endregion
