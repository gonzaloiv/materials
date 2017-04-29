using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadowBehaviour : MonoBehaviour {

  #region Fields

  private float SCALE_RATIO = 90;

  [SerializeField] private GameObject player;
  [SerializeField] private Color color;

  private Rigidbody2D rb;
  private Vector2 initialScale;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = player.GetComponent<Rigidbody2D>();
    initialScale = transform.localScale;
  }

  void Update() {
    if (rb.velocity != Vector2.zero)
      transform.localScale = initialScale + initialScale * rb.velocity.magnitude / SCALE_RATIO;
    else 
      transform.localScale = Vector2.Lerp(transform.localScale, initialScale, 0.1f);
  }

  #endregion

}
