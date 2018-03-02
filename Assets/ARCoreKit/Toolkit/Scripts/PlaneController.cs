using GoogleARCore;
using GoogleARCoreInternal;
using UnityEngine;

namespace ARCoreToolkit
{

    public class PlaneController : MonoBehaviour
    {

        ARCoreSession session;
        LifecycleManager lifecycleManager;
        PlaneStreamer streamer;

        void Start()
        {
            InitPlaneController();
        }

        void InitPlaneController()
        {
            session = GameObject.FindObjectOfType<ARCoreSession>();
            lifecycleManager = LifecycleManager.Instance;
            streamer = GetComponent<PlaneStreamer>();
        }

        public void ChangePlaneTrackingState()
        {
            session.SessionConfig.EnablePlaneFinding = !isPlaneTrackingEnable();
            lifecycleManager.EnableSession();
            streamer.enabled = isPlaneTrackingEnable();
        }

        bool isPlaneTrackingEnable()
        {
            return session.SessionConfig.EnablePlaneFinding;
        }

    }

}
