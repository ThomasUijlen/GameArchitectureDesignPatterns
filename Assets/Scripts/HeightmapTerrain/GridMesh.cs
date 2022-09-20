using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMesh : MonoBehaviour
{
    public void UpdateMesh(GridPoint[,] _grid, float _pointWidth) {
        Mesh mesh = new Mesh();
        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

		SetVertices(mesh, _grid, _pointWidth);
        
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
	}



    private void SetVertices(Mesh _mesh, GridPoint[,] _grid, float _pointWidth) {
        int width = _grid.GetLength(0)-1;
        int height = _grid.GetLength(1)-1;

        Vector3[] vertices = new Vector3[(width) * (height) * 6];
		for (int i = 0, y = 0; y < height; y++) {
			for (int x = 0; x < width; x++, i += 6) {
                Vector3 coord1 = GetVertexPosition(_grid[x,y], _pointWidth);
                Vector3 coord2 = GetVertexPosition(_grid[x+1,y], _pointWidth);;
                Vector3 coord3 = GetVertexPosition(_grid[x,y+1], _pointWidth);;
                Vector3 coord4 = GetVertexPosition(_grid[x+1,y+1], _pointWidth);;

				vertices[i] = coord1;
                vertices[i+1] = coord3;
                vertices[i+2] = coord2;
                vertices[i+3] = coord2;
                vertices[i+4] = coord3;
                vertices[i+5] = coord4;
			}
		}
        
		_mesh.vertices = vertices;

        int[] triangles = new int[vertices.Length];
        for(int i = 0; i < triangles.Length; i++) triangles[i] = i;
		_mesh.triangles = triangles;
    }

    private Vector3 GetVertexPosition(GridPoint _gridPoint, float _pointWidth) {
        return new Vector3(_gridPoint.coordinate.x * _pointWidth, _gridPoint.height, _gridPoint.coordinate.y * _pointWidth);
    }
}
