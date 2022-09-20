using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainEvent : IEvent
{
    private GridPointDecorator decorator;
    private HeightmapTerrain terrain;
    private Vector3 position;

    public TerrainEvent(GridPointDecorator _decorator, HeightmapTerrain _terrain, Vector3 _position) {
        decorator = _decorator;
        terrain = _terrain;
        position = _position;
    }

    public void Execute() {
        GridPoint gridPoint = terrain.GetGridPoint(terrain.GlobalToCoord(position));
        if(gridPoint != null) decorator.Decorate(gridPoint);
    }
}
