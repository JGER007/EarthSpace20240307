using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARManager : MonoBehaviour
{
    private ARRaycastManager aRRaycastManager;
    [SerializeField]
    private GameObject putDownGameObject;

    [SerializeField]
    private GameObject putBtn;

    private List<ARRaycastHit> hits;
    private Vector3 screenCenter;

    private bool isPut = false;

    // Start is called before the first frame update
    void Start ()
    {
        isPut = false;
        hits = new List<ARRaycastHit> ();
        screenCenter = new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f);
        aRRaycastManager = FindObjectOfType<ARRaycastManager> ();
    }

    public void OnPut ()
    {
        if (!isPut)
        {

#if UNITY_EDITOR
            putDownGameObject.gameObject.SetActive (true);
            isPut = true;
#else
        if (aRRaycastManager.Raycast (screenCenter, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose pose = hits [0].pose;
                putDownGameObject.transform.position = pose.position;
                putDownGameObject.gameObject.SetActive (true);
                isPut = true;
            }
#endif
        }

        if (isPut)
        {
            putBtn.SetActive (false);
        }
    }
}
