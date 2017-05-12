using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

  #region Fields

  [SerializeField] private AudioClip gameStartedSound;
  [SerializeField] private AudioClip levelEndSound;
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
    EventManager.StartListening<MaterialSelectionEvent>(OnMaterialSelectionEvent);
  }

  void OnDisable() {
    EventManager.StopListening<PlayerHitEvent>(OnPlayerHitEvent);
    EventManager.StopListening<PlayerSelectionEvent>(OnPlayerSelectionEvent);
    EventManager.StopListening<GoalEvent>(OnGoalEvent);
    EventManager.StopListening<MaterialSelectionEvent>(OnMaterialSelectionEvent);
  }

  #endregion

  #region Event Behaviour

  void OnPlayerHitEvent(PlayerHitEvent playerHitEvent) {
//    audioSource.PlayOneShot(playerHitSounds[Random.Range(0, playerHitSounds.Length)]);
  }

  void OnPlayerSelectionEvent(PlayerSelectionEvent playerSelectionEvent) {
    audioSource.PlayOneShot(playerSelectionSounds[Random.Range(0, playerSelectionSounds.Length)]);
  }

  void OnGoalEvent(GoalEvent goalEvent) {
    AudioClip clip = goalEvent.Goal.IsLevelEnd ? levelEndSound : playerHitSounds[Random.Range(0, playerHitSounds.Length)];
    audioSource.PlayOneShot(clip);
  }

  void OnMaterialSelectionEvent(MaterialSelectionEvent materialSelectionEvent) {
    audioSource.PlayOneShot(playerSelectionSounds[Random.Range(0, playerSelectionSounds.Length)]);
  }

  #endregion

}
