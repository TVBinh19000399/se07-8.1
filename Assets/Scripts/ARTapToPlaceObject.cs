using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject showingPlane;
    public GameObject[] arModels;
    private GameObject spawedObject;
    private ARRaycastManager _arraycastManager;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // public GameObject changePlaneButton;

    private Pose PlacementPose;
    bool isOne = false;

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
            PlacementPose = hits[0].pose;
            if (spawedObject == null)
            {
                spawedObject = Instantiate(showingPlane, PlacementPose.position, PlacementPose.rotation);
            }
            else
            {
                spawedObject.transform.position = PlacementPose.position;
            }



        }


    }

    public void changeObject()
    {
        clearr();
        if (isOne)
        {
            showingPlane = arModels[1];
        }
        else
        {
            showingPlane = arModels[0];
        }
        isOne = !isOne;
        // spawedObject = Instantiate(showingPlane, PlacementPose.position, PlacementPose.rotation);
    }

    public void clearr()
    {
        GameObject clearUp = GameObject.FindGameObjectWithTag("models");
        Destroy(clearUp);
    }


    public void replace1()
    {
        clearr();
        showingPlane = arModels[0];
    }

    public void replace2()
    {
        clearr();
        showingPlane = arModels[1];
    }

    public void replace3()
    {
        clearr();
        showingPlane = arModels[2];
    }

    public void replace4()
    {
        clearr();
        showingPlane = arModels[3];
    }

    public void replace5()
    {
        clearr();
        showingPlane = arModels[4];
    }

    public void replace6()
    {
        clearr();
        showingPlane = arModels[5];
    }

    public void replace7()
    {
        clearr();
        showingPlane = arModels[6];
    }

    public void replace8()
    {
        clearr();
        showingPlane = arModels[7];
    }


}
