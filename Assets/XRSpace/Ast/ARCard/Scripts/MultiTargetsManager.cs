using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class MultiTargetsManager : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager m_ARTrackedImageManager;
    [SerializeField]
    private GameObject [] aRmodelsToPlace;
    private Dictionary<string, GameObject> aRModels = new Dictionary<string, GameObject> ();
    private Dictionary<string, bool> modelState = new Dictionary<string, bool> ();
    void Start ()
    {
        foreach (var item in aRmodelsToPlace)
        {
            GameObject newARModel = Instantiate (item, Vector3.zero, Quaternion.identity);
            newARModel.name = item.name;
            Debug.Log (newARModel.name);
            aRModels.Add (newARModel.name, newARModel);
            newARModel.SetActive (false);
            modelState.Add (newARModel.name, false);

        }
    }

    private void OnEnable ()
    {
        m_ARTrackedImageManager.trackedImagesChanged += M_ARTrackedImageManager_trackedImagesChanged;
    }
    private void OnDisable ()
    {
        m_ARTrackedImageManager.trackedImagesChanged -= M_ARTrackedImageManager_trackedImagesChanged;
    }
    private void M_ARTrackedImageManager_trackedImagesChanged (ARTrackedImagesChangedEventArgs obj)
    {
        foreach (var trackedImage in obj.added)
        {
            ShowARModel (trackedImage);
        }
        foreach (var trackedImage in obj.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                ShowARModel (trackedImage);
            }
            else if (trackedImage.trackingState == TrackingState.Limited)
            {
                HideARModel (trackedImage);
            }
        }
    }
    private void ShowARModel (ARTrackedImage aRTrackedImage)
    {
        bool isModelActivated = modelState [aRTrackedImage.referenceImage.name];
        if (!isModelActivated)
        {
            GameObject aRModel = aRModels [aRTrackedImage.referenceImage.name];
            aRModel.transform.position = aRTrackedImage.transform.position;
            aRModel.SetActive (true);
            modelState [aRTrackedImage.referenceImage.name] = true;
        }
        else
        {
            GameObject aRModel = aRModels [aRTrackedImage.referenceImage.name];
            aRModel.transform.position = aRTrackedImage.transform.position;
        }

    }
    private void HideARModel (ARTrackedImage aRTrackedImage)
    {
        bool isModelActivated = modelState [aRTrackedImage.referenceImage.name];
        if (isModelActivated)
        {
            GameObject aRModel = aRModels [aRTrackedImage.referenceImage.name];
            aRModel.SetActive (false);
            modelState [aRTrackedImage.referenceImage.name] = false;
        }
    }
}

