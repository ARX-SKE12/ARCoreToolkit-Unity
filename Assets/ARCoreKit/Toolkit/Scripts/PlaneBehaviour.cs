using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class PlaneBehaviour : MonoBehaviour {

#region Attributes
    Mesh mesh;
    TrackedPlane referencePlane;
    List<Vector3> vertices;
    List<int> indices;
    Vector3 center;
    int polygonCount;
#endregion

#region Constants
    const float FEATHER_DISTANCE = 0.2f;
    const float FEATHER_SCALE = 0.2f;
#endregion

#region Unity Behaviour
    // Update is called once per frame
    void Update () {
        if (ShouldDestroyPlane()) Destroy(gameObject);
        else if (ShouldRebuildPlane()) BuildReferencePlane();
	}
#endregion

#region Initialize Plane
    public void InitializePlane(TrackedPlane plane)
    {
        mesh = GetComponent<MeshFilter>().mesh;
        referencePlane = plane;
        vertices = new List<Vector3>();
        indices = new List<int>();
    }
#endregion

#region Build Plane
    void BuildReferencePlane()
    {
        referencePlane.GetBoundaryPolygon(vertices);
        center = referencePlane.CenterPose.position;
        polygonCount = vertices.Count;
        BuildInnerVertices();
        BuildIndices(polygonCount);
        BuildMesh();
    }

    void BuildInnerVertices()
    {
        for (int i = 0; i < vertices.Count; ++i)
        {
            Vector3 v = vertices[i];
            Vector3 d = v - center;
            float scale = 1.0f - Mathf.Min(FEATHER_DISTANCE / d.magnitude, FEATHER_SCALE);
            vertices.Add((scale * d) + center);
        }
    }

    void BuildIndices(int ploygonCount)
    {
        indices.Clear();
        for (int i = 0; i < ploygonCount - 2; ++i)
        {
            indices.Add(ploygonCount);
            indices.Add(ploygonCount + i + 1);
            indices.Add(ploygonCount + i + 2);
        }
        for (int i = 0; i < ploygonCount; ++i)
        {
            int outerVertex1 = i;
            int outerVertex2 = ((i + 1) % ploygonCount);
            int innerVertex1 = ploygonCount + i;
            int innerVertex2 = ploygonCount + ((i + 1) % ploygonCount);

            indices.Add(outerVertex1);
            indices.Add(outerVertex2);
            indices.Add(innerVertex1);

            indices.Add(innerVertex1);
            indices.Add(outerVertex2);
            indices.Add(innerVertex2);
        }
    }

    void BuildMesh()
    {
        mesh.Clear();
        mesh.SetVertices(vertices);
        mesh.SetIndices(indices.ToArray(), MeshTopology.Triangles, 0);
    }
    #endregion

#region Plane Status
    bool ShouldRebuildPlane()
    {
        return referencePlane != null;
    }

    bool ShouldDestroyPlane()
    {
        return referencePlane.SubsumedBy != null;
    }
#endregion

}
