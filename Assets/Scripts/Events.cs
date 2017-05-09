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

  public Goal Goal { get { return goal; } }
  private Goal goal;

  public GoalEvent(Goal goal) {
    this.goal = goal;
    Debug.Log("GoalEvent. IsLevelEnd: " + goal.IsLevelEnd);
  }

}

public class MaterialSelectionEvent : UnityEvent {
  public MaterialSelectionEvent() {
    Debug.Log("MaterialSelectionEvent");
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
