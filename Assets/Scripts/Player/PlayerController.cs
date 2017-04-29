using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

  #region Fields

  [SerializeField] private Color bodyColor;
  [SerializeField] private SpriteRenderer shadow;
  [SerializeField] private Color shadowColor;

  [SerializeField] private Vector2 direction;
  [SerializeField] private float force;

  private Rigidbody2D rb;
  private SpriteRenderer rend;
  private Vector2 initialPosition;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    rend = GetComponent<SpriteRenderer>();
    initialPosition = transform.position;
  }

  void Start() {
    rend.color = bodyColor;
    shadow.color = shadowColor;
    ResetRigidbody();
    Player.PlayerMovement = new PlayerMovement(direction, force);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Materials)
      EventManager.TriggerEvent(new PlayerHitEvent());
  }

  #endregion

  #region Public Behaviour

  public void Reset() {
    transform.position = initialPosition;
    Player.PlayerMovement = new PlayerMovement(direction, force);
    Player.IsSelected = false;
    rb.isKinematic = false;
    transform.DOPause();
  }

  public void ResetRigidbody() {
    rb.isKinematic = rb.isKinematic ? false : true;
    rb.velocity = Vector2.zero;
  }

  #endregion

}
