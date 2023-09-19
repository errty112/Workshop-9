// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class GenerateCube : MonoBehaviour
{
    [SerializeField] private Shader shader;
    [SerializeField] private PointLight pointLight;

    private MeshRenderer _renderer;

    private void Start()
    {
        // Generate the mesh and assign to the mesh filter.
        GetComponent<MeshFilter>().mesh = CreateMesh();
        
        // Store renderer reference
        this._renderer = gameObject.GetComponent<MeshRenderer>();

        // Assign custom shader
        this._renderer.material.shader = this.shader;
    }
    
    private void Update()
    {
        // Pass updated light colour to shader
        this._renderer.material.SetColor("_PointLightColor", 
            this.pointLight.GetColor());
        
        // Pass updated light position to shader
        this._renderer.material.SetVector("_PointLightPosition",
            this.pointLight.GetWorldPosition());
    }

    private Mesh CreateMesh()
    {
        // Our beloved cube is back...
        var mesh = new Mesh
        {
            name = "Cube"
        };

        // Define the vertex positions (same as workshop 2).
        mesh.SetVertices(new[]
        {
            // Top face
            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),

            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, -1.0f),

            // Bottom face
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            // Left face
            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),

            // Right face
            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            new Vector3(1.0f, -1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),

            // Front face
            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, 1.0f, 1.0f),

            new Vector3(-1.0f, 1.0f, 1.0f),
            new Vector3(-1.0f, -1.0f, 1.0f),
            new Vector3(1.0f, -1.0f, 1.0f),

            // Back face
            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f),

            new Vector3(-1.0f, -1.0f, -1.0f),
            new Vector3(-1.0f, 1.0f, -1.0f),
            new Vector3(1.0f, -1.0f, -1.0f)
        });

        // Define the vertex colours (same as workshop 2).
        mesh.SetColors(new[]
        {
            // Top face
            Color.red,
            Color.red,
            Color.red,

            Color.red,
            Color.red,
            Color.red,

            // Bottom face
            Color.red,
            Color.red,
            Color.red,

            Color.red,
            Color.red,
            Color.red,

            // Left face
            Color.yellow,
            Color.yellow,
            Color.yellow,

            Color.yellow,
            Color.yellow,
            Color.yellow,

            // Right face
            Color.yellow,
            Color.yellow,
            Color.yellow,

            Color.yellow,
            Color.yellow,
            Color.yellow,

            // Front face
            Color.blue,
            Color.blue,
            Color.blue,

            Color.blue,
            Color.blue,
            Color.blue,

            // Back face
            Color.blue,
            Color.blue,
            Color.blue,

            Color.blue,
            Color.blue,
            Color.blue
        });

        var normals = new Vector3[mesh.vertices.Length];
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            var vertex = mesh.vertices[i];
            normals[i] = vertex.normalized;
        }

        mesh.SetNormals(normals);
        
        // Define the indices (same as workshop 2).
        var indices = Enumerable.Range(0, mesh.vertices.Length).ToArray();
        mesh.SetIndices(indices, MeshTopology.Triangles, 0);

        return mesh;
    }
}
