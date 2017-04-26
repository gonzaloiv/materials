using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  #region Fields 

  private const float MAX_SPEED = 1.5f;

  [SerializeField] GameObject player;
  private Vector3 initialPosition;

  #endregion

  #region Mono Behaviour

  void Awake() {
    initialPosition = transform.position;
  }

  void Update() {
    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, initialPosition.z) , MAX_SPEED * Time.deltaTime);
  }

  #endregion
	
}
