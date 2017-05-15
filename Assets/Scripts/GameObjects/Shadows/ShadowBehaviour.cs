using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShadowBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] protected float SIZE = 0.1f;

  protected Transform material;
  protected Vector2 initialPosition;
  protected Vector2 initialScale;

  #endregion

  #region Mono Behaviour

  protected virtual void Awake() {
    material = GetComponentInParent<Transform>();
    initialPosition = new Vector2(material.position.x + SIZE * material.localScale.x, material.position.y - SIZE * material.localScale.y);
    initialScale = material.localScale;
  }

  protected virtual void Start() {
    transform.position = initialPosition;
    transform.localScale = initialScale;
  }

  #endregion

	
}
