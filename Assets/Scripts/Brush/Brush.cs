using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Brush : MonoBehaviour
{
    public HeightmapTerrain terrain;

    public AnimationCurve intensityCurve;
    public float brushWidth = 2f;
    private Camera camera;

    private void Start() {
        camera = GetComponent<Camera>();
    }

    private void Update() {
        HandleInputs();
    }

    private void HandleInputs() {
        if(Input.GetMouseButton(0)) {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                BrushLocation(hit.point);
            }
        }
    }

    public void BrushLocation(Vector3 _position) {
        IBrushMode brushMode = GetComponentInChildren<IBrushMode>();
        int steps = Mathf.CeilToInt((brushWidth/terrain.pointWidth)/2);
        
        for(int x = -steps; x < steps; x++) {
            for(int y = -steps; y < steps; y++) {
                Vector3 brushPosition = _position+(new Vector3(x,0,y)*terrain.pointWidth);
                float distance = Mathf.Clamp(Vector3.Distance(_position, brushPosition)/(brushWidth/2f), 0f, 1f);

                TerrainEvent terrainEvent = new TerrainEvent(brushMode.CreateDecorator(intensityCurve.Evaluate(distance)), terrain, brushPosition);
                terrain.QueueEvent(terrainEvent);
            }
        }
    }
}

public interface IBrushMode {
    GridPointDecorator CreateDecorator(float intensity);
}
