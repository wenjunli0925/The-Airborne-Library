using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSetupManager : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public Material occlusionMat, planeMat;
    public GameObject planePrefab;
    public GameObject SetOcclusionButton;
    public GameObject SetPlaneButton;

    public void SetOcclusionMaterail()
    {
        planePrefab.GetComponent<Renderer>().material = occlusionMat;

        foreach (var plane in planeManager.trackables)
        {
            plane.GetComponent<Renderer>().material = occlusionMat;
        }
    }

    public void SetPlaneMaterail()
    {
        planePrefab.GetComponent<Renderer>().material = planeMat;

        foreach (var plane in planeManager.trackables)
        {
            plane.GetComponent<Renderer>().material = planeMat;
        }
    }

    public void disableButton()
    {
        SetOcclusionButton.SetActive(false);
        SetPlaneButton.SetActive(false);
    }

    
}
 