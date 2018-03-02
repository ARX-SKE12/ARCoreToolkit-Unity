using UnityEngine;
namespace ARCoreToolkit
{
    public class PlaneColliderBehaviour : MonoBehaviour
    {
        void OnUpdateMesh(Mesh mesh)
        {
            GetComponent<MeshCollider>().sharedMesh = mesh;
        }
    }
}
