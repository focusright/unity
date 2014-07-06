//http://unitytipsandtricks.blogspot.com/2013/08/procedural-meshes-circles.html
using UnityEngine;
using System.Collections;

// =============================================================================
public class ProceduralGeometry  {
	
	// -------------------------------------------------------------------------
	static public Mesh CreateCircle(float radius) {
		
		// The more verts, the more 'round' the circle appears
		// It's hard coded here but it would better if you could pass it in as an argument to this function
		int numVerts = 41;
		
		Mesh plane = new Mesh();
		Vector3[] verts = new Vector3[numVerts];
		Vector2[] uvs = new Vector2[numVerts];
		int[] tris = new int[(numVerts * 3)];
		
		// The first vert is in the center of the triangle
		verts[0] = Vector3.zero;
		uvs[0] = new Vector2(0.5f, 0.5f);
		
		float angle = 360.0f / (float)(numVerts - 1);
		
		for (int i = 1; i < numVerts; ++i) {
			verts[i] = Quaternion.AngleAxis(angle * (float)(i - 1), Vector3.back) * Vector3.up;
			
			float normedHorizontal = (verts[i].x + 1.0f) * 0.5f;
			float normedVertical = (verts[i].x + 1.0f) * 0.5f;
			uvs[i] = new Vector2(normedHorizontal, normedVertical);
		}
		
		for (int i = 0; i + 2 < numVerts; ++i) {
			int index = i * 3;
			tris[index + 0] = 0;
			tris[index + 1] = i + 1;
			tris[index + 2] = i + 2;
		}
		
		// The last triangle has to wrap around to the first vert so we do this last and outside the lop
		var lastTriangleIndex = tris.Length - 3;
		tris[lastTriangleIndex + 0] = 0;
		tris[lastTriangleIndex + 1] = numVerts - 1;
		tris[lastTriangleIndex + 2] = 1;
		
		plane.vertices = verts;
		plane.triangles = tris;	
		plane.uv = uvs;
		
		plane.RecalculateNormals();
		
		return plane;
	}
}
