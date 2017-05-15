using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CameraController : StateMachine {

  #region Fields

  [SerializeField] private float TRAVELLING_SPEED = 1.5f;
  [SerializeField] private float FOCUS_SPEED = 0.01f;
  [SerializeField] GameObject player;

  private Camera cam;
  private Vector3 initialPosition;
  private float initialSize;
  private float nextSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    cam = GetComponent<Camera>();
    initialPosition = transform.position;
    initialSize = cam.orthographicSize;
    nextSize = initialSize;
  }

  void Update() {
    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, initialPosition.z), TRAVELLING_SPEED * Time.deltaTime);
    if(nextSize != cam.orthographicSize)
      cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, nextSize, FOCUS_SPEED);
  }

  #endregion

  #region Public Behaviour

  public void UpdateSize(float scale, float focusSpeed) {
    this.nextSize = initialSize * scale;
    this.FOCUS_SPEED = focusSpeed;
  }

  public void ResetSize(float focusSpeed) {
    this.nextSize = initialSize;
    this.FOCUS_SPEED = focusSpeed;
  }

  #endregion
	
}
