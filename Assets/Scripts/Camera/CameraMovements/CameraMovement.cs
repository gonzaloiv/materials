using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraMovement", menuName = "CameraMovement", order = 1)]
public class CameraMovement : ScriptableObject {

  public CameraMovementType Type { get { return type; } }
  [SerializeField] private CameraMovementType type;

  public float Scale { get { return scale; } }
  [SerializeField] private float scale;

  public float Speed { get { return speed; } }
  [SerializeField] private float speed;

}
