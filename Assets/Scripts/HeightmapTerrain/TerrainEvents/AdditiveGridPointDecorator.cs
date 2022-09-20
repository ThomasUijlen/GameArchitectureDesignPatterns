using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditiveGridPointDecorator : GridPointDecorator
{
    private float addAmount;

    public AdditiveGridPointDecorator(float _addAmount) {
        addAmount = _addAmount;
    }

    public override void Decorate(GridPoint _gridPoint) {
        _gridPoint.height += addAmount;
    }
}
