using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
namespace ARCoreToolkit
{
    public class PlaneGenerator : MonoBehaviour
    {

        #region Plane Components
        public Material planeMaterial;
        public GameObject planePrefab;
    #endregion

        #region Unity Behaviour
            // Use this for initialization
            void Start()
            {
                GameObject.FindObjectOfType<PlaneStreamer>().Register(gameObject);
            }
        #endregion

        #region Plane Detecting
            void OnNewPlanesDetected(List<TrackedPlane> trackedPlanes)
            {
                foreach (TrackedPlane plane in trackedPlanes)
                {
                    GameObject planeObject = Instantiate(planePrefab, Vector3.zero, Quaternion.identity, transform);
                    planeObject.GetComponent<PlaneBehaviour>().InitializePlane(plane);
                    planeObject.GetComponent<MeshRenderer>().material = planeMaterial;
                }
            }
        #endregion

    }
}
