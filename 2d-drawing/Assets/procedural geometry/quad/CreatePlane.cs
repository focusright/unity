//https://www.youtube.com/watch?v=3jHe1FzrKD8
using UnityEngine;
using UnityEditor;
using System.Collections;

public class ProceduralGeometryPlane {

	[MenuItem("GameObject/Create Other/Custom Plane...")]
	static public void CreatePlane() {
		
		Mesh mesh = new Mesh();
		
		Vector3[] verts = new Vector3[4];
		Vector2[] uvs = new Vector2[4];
		int[] tris = new int[6] { 0, 1, 2, 2, 1, 3 };
		
		// Vertex layout
		// 0 ------1
		// |     / |
		// |   /   |		
		// | /     |
		// 2 ------ 3          
		
		verts[0] = -Vector3.right + Vector3.up;
		verts[1] = Vector3.right + Vector3.up;
		verts[2] = -Vector3.right - Vector3.up;
		verts[3] = Vector3.right - Vector3.up;
		
		uvs[0] = new Vector2(0.0f, 1.0f);
		uvs[1] = new Vector2(1.0f, 1.0f);
		uvs[2] = new Vector2(0.0f, 0.0f);
		uvs[3] = new Vector2(1.0f, 0.0f);
		
		mesh.vertices = verts;
		mesh.triangles = tris;	
		mesh.uv = uvs;
		
		mesh.RecalculateNormals();
		
		GameObject newMeshObject = new GameObject();
		newMeshObject.AddComponent<MeshFilter>().mesh = mesh;
		newMeshObject.AddComponent<MeshRenderer>();
		
		AssetDatabase.CreateAsset(mesh, "Assets/SimplePlane.asset");
	}
}
