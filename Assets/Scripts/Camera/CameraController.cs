using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour {

  #region Fields

  private const float MAX_SPEED = 1.5f;

  [SerializeField] GameObject player;
  private Camera cam;
  private Vector3 initialPosition;
  private Vector3 initialSize;

  #endregion

  #region Mono Behaviour

  void Awake() {
    cam = GetComponent<Camera>();
    initialPosition = transform.position;
    initialSize = cam.orthographicSize;
  }

  void Update() {
    transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, initialPosition.z), MAX_SPEED * Time.deltaTime);
  }

  #endregion

  #region Public Behaviour

  public void UpdateSize(int size) {
    cam.orthographic = size;
  }

  #endregion
	
}
