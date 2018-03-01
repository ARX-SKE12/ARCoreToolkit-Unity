using System.Collections.Generic;
using GoogleARCore;
using PublisherKit;

public class PlaneStreamer : Publisher {

    List<TrackedPlane> newPlanes, allPlanes;

    const string NEW_PLANES_EVENT = "OnNewPlanesDetected";

    void Awake()
    {
        InitializePlaneCollector();
    }
	
	// Update is called once per frame
	void Update () {
        StreamPlanes();
	}

    void InitializePlaneCollector()
    {
        newPlanes = new List<TrackedPlane>();
        allPlanes = new List<TrackedPlane>();
    }

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

    bool IsTracking()
    {
        return Session.Status == SessionStatus.Tracking;
    }

}
