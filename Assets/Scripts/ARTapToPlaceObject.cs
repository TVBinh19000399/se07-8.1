using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject showingPlane;
    public GameObject[] arModels;
    private GameObject spawedObject;
    private ARRaycastManager ACManager;
    private Vector2 touchPosition;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Pose PlacementPose;
    public float m_Min = 0f;
    public float m_Max = 360f;
    Slider m_Slider;
    private void Awake()
    {
        ACManager = GetComponent<ARRaycastManager>();
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
        if (ACManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
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
    //scale obj
    public void scale()
    {

    }


    //rotate obj
    public void rotate()
    {

    }


}
