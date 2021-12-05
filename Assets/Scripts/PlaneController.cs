using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARPlaneManager))]
public class PlaneController : MonoBehaviour
{
    [Tooltip("Hien thi hoac an Plane.")]
    [SerializeField]
    Text togglePlaneText;
    ARPlaneManager ARPlaneManager;
    public Text togglePlaneTxt
    {
        get { return togglePlaneText; }
        set { togglePlaneText = value; }
    }
    void Awake()
    {
        ARPlaneManager = GetComponent<ARPlaneManager>();
    }

    public void TogglePlane()
    {
        ARPlaneManager.enabled = !ARPlaneManager.enabled;

        string planeDetectionMessage = "";
        if (ARPlaneManager.enabled)
        {
            planeDetectionMessage = "Hide Plane";
            SetAllPlanesActive(true);
        }
        else
        {
            planeDetectionMessage = "Show Plane";
            SetAllPlanesActive(false);
        }

        if (togglePlaneTxt != null)
            togglePlaneTxt.text = planeDetectionMessage;
    }

    void SetAllPlanesActive(bool value)
    {
        foreach (var plane in ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }


}