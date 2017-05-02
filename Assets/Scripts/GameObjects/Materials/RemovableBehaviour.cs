using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;


public class RemovableBehaviour : LeanSelectableBehaviour {

  #region Fields

  private Animator anim;

  #endregion

  #region Mono Behaviour

  void Awake() {
    anim = GetComponent<Animator>();
  }

  #endregion

  #region Lean Selectable Behaviour

  protected override void OnSelect(LeanFinger finger) {
    anim.Play("FadeOut");
  }

  #endregion

}
