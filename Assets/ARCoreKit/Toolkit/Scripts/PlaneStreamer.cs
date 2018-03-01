using System.Collections.Generic;
using GoogleARCore;
using PublisherKit;

public class PlaneStreamer : Publisher {

#region Attributes
    List<TrackedPlane> newPlanes, allPlanes;
    #endregion

#region Events
    const string NEW_PLANES_EVENT = "OnNewPlanesDetected";
#endregion

#region Untiy Behaviour
    void Awake()
    {
        InitializePlaneCollector();
    }
	
	// Update is called once per frame
	void Update () {
        StreamPlanes();
	}
#endregion

#region Plane Collector
    void InitializePlaneCollector()
    {
        newPlanes = new List<TrackedPlane>();
        allPlanes = new List<TrackedPlane>();
    }
#endregion

#region Planes Streamer
    void StreamPlanes()
    {
        if (IsTracking())
        {
            StreamNewPlanes();
        }
    }

    void StreamNewPlanes()
    {
        Session.GetTrackables<TrackedPlane>(newPlanes, TrackableQueryFilter.New);
        Broadcast(NEW_PLANES_EVENT, newPlanes);
    }

    public List<TrackedPlane> GetAllTrackedPlane()
    {
        if (!IsTracking()) return null;
        Session.GetTrackables<TrackedPlane>(allPlanes, TrackableQueryFilter.All);
        return allPlanes;
    }
#endregion

#region Tracking Status
    bool IsTracking()
    {
        return Session.Status == SessionStatus.Tracking;
    }
#endregion

}
