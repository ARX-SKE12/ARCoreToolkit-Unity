using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
namespace ARCoreToolkit
{
    public class PlaneGenerator : MonoBehaviour
    {

        public Material planeMaterial;
        public GameObject planePrefab;

        // Use this for initialization
        void Start()
        {
            GameObject.FindObjectOfType<PlaneStreamer>().Register(gameObject);
        }

        void OnNewPlanesDetected(List<TrackedPlane> trackedPlanes)
        {
            foreach (TrackedPlane plane in trackedPlanes)
            {
                GameObject planeObject = Instantiate(planePrefab, Vector3.zero, Quaternion.identity, transform);
                planeObject.GetComponent<PlaneBehaviour>().InitializePlane(plane);
                planeObject.GetComponent<MeshRenderer>().material = planeMaterial;
            }
        }

    }
}
