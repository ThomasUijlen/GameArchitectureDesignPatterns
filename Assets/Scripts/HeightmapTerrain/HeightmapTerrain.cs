using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightmapTerrain : MonoBehaviour
{
    //Grid variables
    public GridMesh gridMesh;
    public int size = 20;
    public float pointWidth = 1f;
    public float updateInterval = 0.1f;
    private GridPoint[,] grid;

    //Queue variables
    private Queue<IEvent> eventQueue = new Queue<IEvent>();
    private float eventTimer = 0.0f;

    private void Start()
    {
        CreateGrid();
        gridMesh.UpdateMesh(grid, pointWidth);
    }

    private void Update() {
        if(eventQueue.Count > 0){
            eventTimer -= Time.deltaTime;
            if(eventTimer <= 0.0) {
                eventTimer = updateInterval;
                ExecuteEventQueue();
                gridMesh.UpdateMesh(grid, pointWidth);
            }
        }
    }

    private void CreateGrid()
    {
        grid = new GridPoint[size, size];

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                grid[x,y] = new GridPoint(new Vector2(x, y));
            }
        }
    }

    private void ExecuteEventQueue()
    {
        while(eventQueue.Count > 0) eventQueue.Dequeue().Execute();
    }

    public void QueueEvent(IEvent _event) {
        eventQueue.Enqueue(_event);
    }

    public GridPoint GetGridPoint(Vector2Int _coordinate) {
        if(_coordinate.x < 0 || _coordinate.y < 0 || _coordinate.x >= size || _coordinate.y >= size) return null;
        return grid[_coordinate.x, _coordinate.y];
    }

    public Vector2Int GlobalToCoord(Vector3 _global) {
        return Vector2Int.RoundToInt(new Vector2(_global.x-transform.position.x, _global.z-transform.position.z) / pointWidth);
    }
}
