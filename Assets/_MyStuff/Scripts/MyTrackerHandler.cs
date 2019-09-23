using UnityEngine;
using Vuforia;

public class MyTrackerHandler : MonoBehaviour, ITrackableEventHandler
{

    public TrackableBehaviour trackableBehaviour;

    private void Awake()
    {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
    }

    void Start()
    {
        if (trackableBehaviour == null)
        {
            Debug.LogError("TrackableBehaviour is NULL");
        }
        else
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TrackerManager.Instance.GetTracker<ObjectTracker>().Start();
        }
    }


    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED)
        {
            print("Found");
            TrackerManager.Instance.GetTracker<ObjectTracker>().Stop();
        }
        else
        {
            print("Lost");
        }
    }
}
