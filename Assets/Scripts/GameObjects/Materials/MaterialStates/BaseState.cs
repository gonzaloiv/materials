using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaterialStates {

  public class BaseState : State {

    #region Fields

    protected SpriteRenderer shadow;
    protected MaterialShadowBehaviour shadowBehaviour;

    #endregion

    #region Mono Behaviour

    protected virtual void Awake() {
      shadow = GetComponentsInChildren<SpriteRenderer>()[1];
      shadowBehaviour = shadow.GetComponent<MaterialShadowBehaviour>();
    }

    #endregion
	
  }

}