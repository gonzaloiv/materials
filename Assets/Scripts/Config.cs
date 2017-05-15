using UnityEngine;
using System.Collections.Generic;

public class Config {
  public static Vector2 STANDARD_DEFINITION = new Vector2(1280, 800);
}

public enum Layer {
  Materials = 8,
  Player = 9,
  Goal = 10
}

public enum Direction {
  Up,
  Right,
  Down,
  Left
}

public enum CameraMovementType {
  Reset,
  Zoom
}