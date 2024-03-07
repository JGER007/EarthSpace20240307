using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPutManager : MonoBehaviour
{
    #region Private Parameters
    private List<ARRaycastHit> hits = new List<ARRaycastHit> ();
    [SerializeField]
    ARRaycastManager arRaycastManager;
    [SerializeField]
    private BasePutManager basePutManager;


    #endregion

    private void Start ()
    {
        hits = new List<ARRaycastHit> ();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.touchCount > 0 && Input.touches [0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject ())
            {
                Debug.Log ("点击到UI");
                return;
            }

            Vector2 touchPoint = Input.touches [0].position;
            if (arRaycastManager.Raycast (touchPoint, hits, TrackableType.PlaneWithinPolygon))
            {
                // 列表中元素是按命中的距离排序的，所以第一个命中的距离是最近的。
                var hitPose = hits [0].pose;
                basePutManager.SetPutOn (hitPose.position, hitPose.rotation);
            }
        }
    }

}
