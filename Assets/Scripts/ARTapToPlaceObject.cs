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
    public Slider slider;
    // private ARSessionOrigin SessionOrigin;
    private void Awake()
    {
        ACManager = GetComponent<ARRaycastManager>();
        // SessionOrigin = GetComponent<ARSessionOrigin>();
    }

    bool GetTouchPos(out Vector2 touchPosition)
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
        if (!GetTouchPos(out Vector2 touchPosition))
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
    //ti le scale trung voi value cua slide
    public void OnSliderValueChanged()
    {
        Slider slider = GameObject.FindGameObjectWithTag("scalesl").GetComponent<Slider>();
        spawedObject.transform.localScale = new Vector3(slider.value, slider.value, slider.value);
    }
    //xoay 9 do moi lan nhan
    public void LeftRotation()
    {
        float rx = spawedObject.transform.rotation.x;
        float ry = spawedObject.transform.rotation.y - 9;
        float rz = spawedObject.transform.rotation.z;
        // spawedObject.transform.localEulerAngles = new Vector3(rx, ry, rz);
        spawedObject.transform.Rotate(new Vector3(rx, ry, rz));
    }
    public void RightRotation()
    {
        float rx = spawedObject.transform.rotation.x;
        float ry = spawedObject.transform.rotation.y + 9;
        float rz = spawedObject.transform.rotation.z;
        spawedObject.transform.Rotate(new Vector3(rx, ry, rz));
    }
    public void MakeInvisible()
    {
        spawedObject.transform.localScale = new Vector3(0, 0, 0);
    }
    public void MakeVisible()
    {
        spawedObject.transform.localScale = new Vector3(0.03f, 0.001f, 0.03f);
    }
}
