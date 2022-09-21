using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainEvent : IEvent
{
    private GridPointDecorator decorator;
    public HeightmapTerrain terrain;
    private Vector3 position;
    private bool undecorate = false;

    public TerrainEvent(GridPointDecorator _decorator, HeightmapTerrain _terrain, Vector3 _position, bool _undecorate) {
        decorator = _decorator;
        terrain = _terrain;
        position = _position;
        undecorate = _undecorate;
    }

    public void Execute() {
        GridPoint gridPoint = terrain.GetGridPoint(terrain.GlobalToCoord(position));
        if(gridPoint != null) {
            if(undecorate) {
                decorator.UnDecorate(gridPoint);
            } else {
                decorator.Decorate(gridPoint);
            }
        }
    }

    public void SetUnDecorate(bool _undecorate) {
        undecorate = _undecorate;
    }
}
