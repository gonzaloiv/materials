using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadowBehaviour : MonoBehaviour {

  #region Fields

  private float SCALE_RATIO = 30;

  [SerializeField] private GameObject shadow;
  [SerializeField] private Color color;

  private Rigidbody2D rb;
  private Vector2 initialScale;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rb = GetComponent<Rigidbody2D>();
    initialScale = shadow.transform.localScale;
  }

  void Update() {
    if (rb.velocity != Vector2.zero)
      shadow.transform.localScale = initialScale + initialScale * rb.velocity.magnitude / SCALE_RATIO;
    else 
      shadow.transform.localScale = Vector2.Lerp(shadow.transform.localScale, initialScale, 0.1f);
  }

  #endregion

}
