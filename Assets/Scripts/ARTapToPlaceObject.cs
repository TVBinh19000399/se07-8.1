using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gmaeObjectToInstantiate;
    private GameObject spawedObject;
    private ARRaycastManager _arraycastManager;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();


    private void Awake()
    {
        _arraycastManager = GetComponent<ARRaycastManager>();

    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        if (_arraycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if (spawedObject == null)
            {
                spawedObject = Instantiate(gmaeObjectToInstantiate, hitPose.position, hitPose.rotation);
            }
            else
            {
                spawedObject.transform.position = hitPose.position;
            }



        }


    }



}
