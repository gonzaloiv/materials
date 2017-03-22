using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

[RequireComponent(typeof(Animator))]
public class RunningBehaviour : LeanSelectableBehaviour {

  #region Fields

  private const float SPEED = 8;

  private Animator anim;
  private bool running = false;
  private bool selected = false;

  #endregion

  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
  }

  void Update() {
    if(running)
      transform.position += new Vector3(1 ,0, 0) * SPEED * Time.deltaTime;
  }

  void OnBecameInvisible() {
    transform.position = new Vector2(-9, -1);
  }

  void OnCollisionEnter2D(Collision2D collision2D) {
    if(collision2D.gameObject.layer == (int) Layer.Materials)
      EventManager.TriggerEvent(new PlayerHitEvent());
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    if (!selected) {
      running = !running;
      if (anim.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        anim.Play("Idle");
      else
        anim.Play("Running");
      selected = true;
      Timer.Register(.3f, () => selected = false);
    }
  }

  #endregion

}
