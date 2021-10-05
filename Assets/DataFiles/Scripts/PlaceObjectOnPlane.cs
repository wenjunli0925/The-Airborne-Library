using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class PlaceObjectOnPlane : MonoBehaviour
{
    private ARPlaneManager planeManager;
    private ARRaycastManager raycasManager;

    private List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    public GameObject placedPrefab;

    private void Awake()
    {
        raycasManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        Touch touch = Input.GetTouch(0);

        if(touch.phase == TouchPhase.Began && !IsPointerOverUIObject())
        {
            if (raycasManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = s_Hits[0].pose;
                Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
            }
        }

        
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
}
