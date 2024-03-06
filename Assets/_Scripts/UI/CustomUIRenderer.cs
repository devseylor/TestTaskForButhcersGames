using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CustomUIRenderer : MonoBehaviour
{
    public CanvasRenderer _renderer;
    public Material _material;
    private float thickness = 10;
    public Color _color = Color.blue;


    private void Start()
    {
        Vector2 p1 = new Vector2(0, 150);
        Vector2 p2 = new Vector2(100, 150);
    }
    public Mesh CreateLineMesh(Vector2 p1, Vector2 p2)
    {
        Mesh mesh = new Mesh();
        VertexHelper vh = new VertexHelper();
        Vector3[] vertices = new Vector3[4];
        Vector2[] uvs = new Vector2[4];
        int[] triangles = new int[6];
        vertices[0] = new Vector3(p1.x, p1.y + thickness / 2);
        vertices[1] = new Vector3(p1.x, p1.y - thickness / 2);
        vertices[2] = new Vector3(p2.x, p2.y + thickness / 2);
        vertices[3] = new Vector3(p2.x, p2.y - thickness / 2);
        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;
        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        // _renderer.SetMaterial(_material,3);
        //_renderer.SetMesh(mesh);
        return mesh;
    } 

}
