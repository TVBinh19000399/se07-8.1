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
    private GameObject defaultPlane;
    bool isFilled = false;
    public ARSession arSession;
    public Text togglePlaneTxt
    {
        get { return togglePlaneText; }
        set { togglePlaneText = value; }
    }
    void Awake()
    {
        ARPlaneManager = GetComponent<ARPlaneManager>();
        defaultPlane = GameObject.FindGameObjectWithTag("PlaneTag");
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

    public void SetAllPlanesActive(bool value)
    {
        foreach (var plane in ARPlaneManager.trackables)
            plane.gameObject.SetActive(value);
    }


    //fill toan bo mat phang
    public void ChangeAllPlaneMaterial()
    {
        if (isFilled)
        {
            arSession.Reset();
        }
        else
        {
            GameObject curentObject = GameObject.FindGameObjectWithTag("models");
            Material mat = curentObject.GetComponent<Renderer>().material;
            foreach (var plane in ARPlaneManager.trackables)
                plane.gameObject.GetComponent<Renderer>().material = mat;

        }
        isFilled = !isFilled;
    }
}