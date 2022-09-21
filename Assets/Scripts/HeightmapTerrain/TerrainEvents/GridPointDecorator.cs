using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridPointDecorator
{
    public abstract void Decorate(GridPoint _gridPoint);
    public abstract void UnDecorate(GridPoint _gridPoint);
}
