using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint
{
    public Vector2 coordinate;
    public float height = 0.0f;

    public GridPoint(Vector2 _coordinate) {
        coordinate = _coordinate;
    }
}
