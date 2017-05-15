using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotableShadowBehaviour : MaterialShadowBehaviour {

  #region Mono Behaviour

  void Update() {
    transform.position = initialPosition;
    transform.rotation = material.transform.rotation;
  }

  #endregion

	
}
