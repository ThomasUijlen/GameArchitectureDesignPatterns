using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditiveBrushMode : MonoBehaviour, IBrushMode
{
    public float strength = 1.0f;
    public GridPointDecorator CreateDecorator(float intensity) {
        return new AdditiveGridPointDecorator(intensity*strength*Time.deltaTime);
    }
}
