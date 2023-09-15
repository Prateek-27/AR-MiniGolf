using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class spawnFlags : MonoBehaviour
{
    [SerializeField] private GameObject[] flagPrefabs;

    private Dictionary<string, GameObject> spawnedFlags = new Dictionary<string, GameObject>();
    private ARTrackedImageManager imageManager;

    private void Awake()
    {
        imageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach (GameObject flag in flagPrefabs)
        {
            GameObject newFlag = Instantiate(flag, new Vector3(0, -1000, 0), Quaternion.identity);
            newFlag.name = flag.name;
            spawnedFlags.Add(flag.name, newFlag);
        }
    }


    private void OnEnable()
    {
        imageManager.trackedImagesChanged += Changed;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= Changed;
    }

    private void Changed(ARTrackedImagesChangedEventArgs Args)
    {
        foreach(ARTrackedImage imageTracked in Args.added)
        {
            ImageUpdate(imageTracked);
        }
        foreach (ARTrackedImage imageTracked in Args.updated)
        {
            ImageUpdate(imageTracked);
        }
        foreach (ARTrackedImage imageTracked in Args.removed)
        {
            spawnedFlags[imageTracked.name].SetActive(false);
        }
    }

    private void ImageUpdate(ARTrackedImage imageTracked)
    {
        string name = imageTracked.referenceImage.name;
        Vector3 position = imageTracked.transform.position;

        GameObject flag = spawnedFlags[name];
        flag.transform.position = position;
        flag.SetActive(true);

        foreach (KeyValuePair<string, GameObject> kvp in spawnedFlags)
        {
            if (kvp.Key != name)
            {
                kvp.Value.SetActive(true);
            }
        }
    }

}
