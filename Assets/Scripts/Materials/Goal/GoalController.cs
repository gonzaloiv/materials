using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GoalController : MonoBehaviour {

  #region Fields

  [SerializeField] private Vector2 direction;
  [SerializeField] private float force;

  private Tweener shaking;
  private bool active;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shaking = transform.DOShakeScale(1f, 0.2f, 5, 180, true).SetEase(Ease.InOutBounce).SetLoops(-1).Pause();
  }

  void OnEnable() {
    active = true;
  }

  void Update() {
    if(!shaking.IsPlaying() && active)
      shaking.Play();
  }

  void OnTriggerEnter2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Player) {
      active = false;
      shaking.Rewind();
      Player.PlayerMovement = new PlayerMovement(direction, force);
    }
  }

  void OnTriggerExit2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Player) {
      active = true;
    }
  }

  #endregion
	
}
