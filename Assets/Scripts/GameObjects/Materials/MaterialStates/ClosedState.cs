using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MaterialStates {

  public class ClosedState : BaseState {

    #region Fields

    private Rigidbody2D rb;
    private Tweener closing;

    #endregion

    #region Mono Behaviour

    void Awake() {
      rb = GetComponent<Rigidbody2D>();
      closing = transform.DOScale(0.2f, 0.5f).Pause();
      closing.OnComplete(Disable);
    }

    #endregion

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      closing.Play();
      rb.simulated = false;
    }

    public override void Exit() {
      base.Exit();
      rb.simulated = true;
    }

    #endregion

    #region Private Behaviour

    private void Disable() {
      gameObject.SetActive(false);
    }

    #endregion
   
  }

}

