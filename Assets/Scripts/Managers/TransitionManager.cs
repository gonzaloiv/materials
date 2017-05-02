using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour {

  #region Fields

  [SerializeField] private GameObject[] transitionPrefabs;
  private GameObject[] transitions;
  private int currentTransition = 0;

  #endregion

  #region Mono Behaviour

  void Awake() {
    transitions = new GameObject[transitionPrefabs.Length];
    for(int i = 0; i < transitionPrefabs.Length; i++) {
      GameObject transition = Instantiate(transitionPrefabs[i], transform);
      transition.SetActive(false);
      transitions[i] = transition;
    }
  }

  void OnEnable() {
    EventManager.StartListening<GoalEvent>(OnGoalEvent);
  }

  void OnDisable() {
    EventManager.StopListening<GoalEvent>(OnGoalEvent);
  }

  #endregion

  #region Event Behaviour

  void OnGoalEvent(GoalEvent goalEvent) {
    if(goalEvent.IsLevelEnd)
      transitions[currentTransition].SetActive(true);
  }

  #endregion

}
