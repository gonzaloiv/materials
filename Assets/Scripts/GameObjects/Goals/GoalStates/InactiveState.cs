using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace GoalStates {

  public class InactiveState : State {

    #region Fields

    private static Color INACTIVE_COLOR = new Color(117, 117, 117, 1);

    private static Color initialColor;
    private SpriteRenderer spriteRenderer;

    #endregion

    #region Mono Behaviour

    void Awake() {
      spriteRenderer = GetComponent<SpriteRenderer>();
      initialColor = spriteRenderer.color;
    }

    #endregion

    #region State Behaviour

    public override void Enter() {
      base.Enter();
      transform.DOPause();
      spriteRenderer.color = INACTIVE_COLOR;
    }

    public override void Exit() {
      base.Exit();
      spriteRenderer.color = initialColor;
    }

    #endregion
   
  }

}