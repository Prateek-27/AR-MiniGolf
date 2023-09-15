using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class BuildMode : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    [SerializeField] private ARPlaneManager planeManager;
    private bool mode = false;
    public GameObject cube;
    public GameObject build_canvas;
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    private void Update()
    {
        mode = GetComponent<PlaneSelection>().buildmode;

        if (mode)
        {
            build_canvas.SetActive(true);
            //GameObject obj = Instantiate(cube);

        }
        else
        {
            build_canvas.SetActive(false);
        }
    }
}
