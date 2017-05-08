using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

  #region Fields

  [SerializeField] private AudioClip gameStartedSound;
  [SerializeField] private AudioClip[] playerHitSounds;
  [SerializeField] private AudioClip[] playerSelectionSounds;

  private AudioSource audioSource;

  #endregion

  #region Mono Behaviour

  void Awake() {
    audioSource = GetComponent<AudioSource>();
  }

  void OnEnable() {
    audioSource.PlayOneShot(gameStartedSound);
    EventManager.StartListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StartListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
    EventManager.StartListening<GoalEvent>(OnGoalEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StopListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
    EventManager.StopListening<GoalEvent>(OnGoalEvent);
  }

  #endregion

  #region Event Behaviour

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
    audioSource.PlayOneShot(playerHitSounds[Random.Range(0, playerHitSounds.Length)]);
  }

  void OnPlayerSelectionEvent(PlayerSelectionEvent playerSelectionEvent) {
    audioSource.PlayOneShot(playerSelectionSounds[Random.Range(0, playerSelectionSounds.Length)]);
  }

  void OnGoalEvent(GoalEvent goalEvent) {
    audioSource.PlayOneShot(playerSelectionSounds[Random.Range(0, playerSelectionSounds.Length)]);
  }

  #endregion

}
