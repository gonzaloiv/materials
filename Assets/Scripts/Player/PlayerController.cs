using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  #region Fields

  [SerializeField] private Color bodyColor;
  [SerializeField] private SpriteRenderer shadow;
  [SerializeField] private Color shadowColor;
  private Rigidbody2D rb;
  private SpriteRenderer rend;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    rend = GetComponent<SpriteRenderer>();
  }

  void OnEnable() {
    rend.color = bodyColor;
    shadow.color = shadowColor;
    ResetRigidbody();
  }

  #endregion

  #region Public Behaviour

  public void ResetRigidbody() {
    rb.isKinematic = rb.isKinematic ? false : true;
    rb.velocity = Vector2.zero;
  }

  #endregion

}
