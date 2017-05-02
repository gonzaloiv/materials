using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FadeInBehaviour : MonoBehaviour {

  #region Fields

  [SerializeField] private Color color;
  [SerializeField] private float duration;

  private SpriteRenderer rend;
  private Tweener anim;

  #endregion

  #region Mono Behaviour

  void Awake() {
    rend = GetComponent<SpriteRenderer>();
    rend.color = color;
    anim = rend.DOFade(1, duration).Pause();
    anim.OnStepComplete(OnComplete);
  }

  void OnEnable() {
    Vector2 cameraPosition = Camera.main.transform.position;
    transform.position = new Vector2(cameraPosition.x + rend.bounds.center.x, cameraPosition.y + rend.bounds.center.y);
    anim.Play();
  }

  void OnDisable() {
    anim.Rewind();
  }

  #endregion

  #region Private Behaviour

  private void OnComplete() {
    EventManager.TriggerEvent(new LevelEndEvent());
  }

  #endregion
	
}
