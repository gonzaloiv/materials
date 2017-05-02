using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class GoalController : MonoBehaviour {

  #region Fields

  private const float TRIGGER_TIME = 1f; 

  [SerializeField] private Vector2 direction;
  [SerializeField] private float force;
  [SerializeField] private bool isLevelEnd = false;

  private Tweener shaking;
  private bool active;
  private float timestamp;

  #endregion

  #region Mono Behaviour

  void Awake() {
    shaking = transform.DOShakeScale(1f, 0.2f, 5, 180, true).SetEase(Ease.InOutBounce).SetLoops(-1).Pause();
  }

  void OnEnable() {
    active = true;
    timestamp = Time.time;
  }

  void Update() {
    if (!shaking.IsPlaying() && active)
      shaking.Play();
  }

  void OnTriggerEnter2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Player && timestamp + TRIGGER_TIME < Time.time) {
      active = false;
      shaking.Rewind();
      Player.PlayerMovement = new PlayerMovement(direction, force);
      EventManager.TriggerEvent(new GoalEvent(isLevelEnd));
    }
  }

  void OnTriggerExit2D(Collider2D collider2D) {
    if (collider2D.gameObject.layer == (int) Layer.Player) {
      active = true;
    }
  }

  #endregion
	
}
