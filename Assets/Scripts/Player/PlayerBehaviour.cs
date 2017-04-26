using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class PlayerBehaviour : LeanSelectableBehaviour {

  #region Fields

  private PlayerController playerController;
  private Vector2 initialPosition;

  private bool selected;
  private Tweener shaking;

  #endregion

  #region Mono Behaviour

  void Awake() {
    playerController = GetComponent<PlayerController>();
    initialPosition = transform.position;
    shaking = transform.DOShakeScale(1f, 0.1f, 5, 180, true).SetLoops(-1).Pause();
  }

  void Update() {
    if (shaking != null && !shaking.IsPlaying() && !selected)
      shaking.Play();
  }

  void OnBecameInvisible() {
    transform.position = initialPosition;
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Materials)
      EventManager.TriggerEvent(new PlayerHitEvent());
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    playerController.ResetRigidbody();
    selected = !selected;
    shaking.Rewind();
  }

  #endregion

}
