using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MaterialShadowBehaviour : ShadowBehaviour {

  #region Fields

  protected SpriteRenderer sprite;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    base.Awake();
    sprite = GetComponent<SpriteRenderer>();
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
