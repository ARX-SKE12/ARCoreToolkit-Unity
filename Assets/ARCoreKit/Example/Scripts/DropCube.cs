using UnityEngine;

namespace ARCoreToolkit.Example
{
    public class DropCube : MonoBehaviour
    {

        public GameObject cube, firstPersonCamera;

        public void Drop()
        {
            Vector3 cameraPosition = firstPersonCamera.transform.position;
            Vector3 cameraDirection = firstPersonCamera.transform.forward;
            Vector3 dropPosition = cameraPosition + cameraDirection * 0.5f;
            Instantiate(cube, dropPosition, Quaternion.identity);
        }

    }
}

