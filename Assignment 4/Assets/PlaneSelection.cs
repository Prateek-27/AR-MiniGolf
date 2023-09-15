using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneSelection : MonoBehaviour
{
    private List<ARPlane> allPlanes = new List<ARPlane>();
    private List<ARPlane> allSelectedPlanes = new List<ARPlane>();
    private bool detection = true;
    private bool firstPlaneSelected = false;

    public bool buildmode = false;

    void Start()
    {
        ARPlaneManager arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlanesChanged;
    }

    void PlanesChanged(ARPlanesChangedEventArgs EvntArgs)
    {
        foreach (ARPlane plane in EvntArgs.added)
        {
            allPlanes.Add(plane);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (detection)
            {
                Ray raycasted = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(raycasted, out hit))
                {
                    // Get the plane that was tapped on
                    ARPlane planeSelected = hit.transform.GetComponent<ARPlane>();

                    if (planeSelected != null)
                    {
                        // Removing it from all planes as will disable planes in all planes afterwards 
                        allPlanes.Remove(planeSelected);

                        if (!allSelectedPlanes.Contains(planeSelected))
                       
                        {
                            /*
                            // Color the planes (Extra Credit)
                            if(allSelectedPlanes.Count == 0)
                            {
                                // Select plane
                                firstPlaneSelected = true;
                                allSelectedPlanes.Add(planeSelected);
                                planeSelected.GetComponent<MeshRenderer>().material.color = Color.green;
                            }
                            if (allSelectedPlanes.Count == 1)
                            {
                                // Select plane
                                firstPlaneSelected = false;
                                allSelectedPlanes.Add(planeSelected);
                                planeSelected.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            }
                            */
                            // Select plane and add it to all the selected planes list
                            allSelectedPlanes.Add(planeSelected);
                            planeSelected.GetComponent<MeshRenderer>().material.color = Color.green;

                            // Disable all other planes except the selected ones 
                            if (allSelectedPlanes.Count == 2)
                            {
                                ARPlaneManager planeManager = GetComponent<ARPlaneManager>();
                                planeManager.enabled = false;

                                foreach (ARPlane plane in allPlanes)
                                {
                                    if (!allSelectedPlanes.Contains(plane))
                                    {
                                        plane.gameObject.SetActive(false);
                                    }
                                }
                                //Disable plane detection and start build mode
                                detection = false;
                                buildmode = true;
                            }
                        }
                    }
                }
            }
            
        }
    }
}