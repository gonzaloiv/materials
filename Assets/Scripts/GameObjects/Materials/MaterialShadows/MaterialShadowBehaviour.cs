using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MaterialShadowBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] protected float SIZE = 0.1f;

  protected Transform material;
  protected SpriteRenderer sprite;
  protected Vector2 initialPosition;
  protected Vector2 initialScale;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    material = GetComponentInParent<Transform>();
    sprite = GetComponent<SpriteRenderer>();
    initialPosition = new Vector2(material.position.x + SIZE * material.localScale.x, material.position.y - SIZE * material.localScale.y);
    initialScale = material.localScale;
  }

  protected virtual void Start() {
    transform.position = initialPosition;
    transform.localScale = initialScale;
  }

  protected virtual void OnEnable() {
    sprite.enabled = true;
    sprite.DOColor(new Color(sprite.color.r, sprite.color.b, sprite.color.g, 0.2f), 1f);
  }

  protected virtual void OnDisable() {
    sprite.DOColor(new Color(sprite.color.r, sprite.color.b, sprite.color.g, 0), 0.5f);
    sprite.enabled = false;
  }

  #endregion

	
}
