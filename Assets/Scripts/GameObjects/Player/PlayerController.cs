using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {

  #region Fields

  [SerializeField] private Color bodyColor;
  [SerializeField] private SpriteRenderer shadow;
  [SerializeField] private Color shadowColor;

  private Player player;
  private Rigidbody2D rb;
  private SpriteRenderer rend;
  private Vector2 initialPosition;

  #endregion

  #region Mono Behaviour

  void Awake() {
    player = GetComponent<Player>();
    rb = GetComponent<Rigidbody2D>();
    rend = GetComponent<SpriteRenderer>();
    initialPosition = transform.position;
  }

  void Start() {
    rend.color = bodyColor;
    shadow.color = shadowColor;
    ResetRigidbody();
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if (collision2D.gameObject.layer == (int) Layer.Materials)
      EventManager.TriggerEvent(new PlayerHitEvent());
  }

  #endregion

  #region Public Behaviour

  public void Reset() {
    transform.position = initialPosition;
    player.Reset();
    rb.isKinematic = false;
    rb.velocity = Vector2.zero;
    transform.DOPause();
  }

  public void ResetRigidbody() {
    rb.isKinematic = rb.isKinematic ? false : true;
    transform.DOPause();
    rb.velocity = Vector2.zero;
  }

  public void AddForce(Vector2 force) {
    rb.AddForce(force);
  }

  #endregion

}
