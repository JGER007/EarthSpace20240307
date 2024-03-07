using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class NFTPutManager : MonoBehaviour
{
    [SerializeField]
    private GameObject nFTSceneObj;
    private ARPlaneManager aRPlaneManager;
    private ARRaycastManager arRaycastManager;
    private NFTUIManager nftUIManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit> ();

    private Vector2 centerV2;
    private bool isPutOn = false;


    void Start ()
    {
        isPutOn = false;
        centerV2 = new Vector2 ();
        centerV2.x = Screen.width / 2;
        centerV2.y = Screen.height / 2;

        aRPlaneManager = FindObjectOfType<ARPlaneManager> ();
        arRaycastManager = FindObjectOfType<ARRaycastManager> ();
        nftUIManager = FindObjectOfType<NFTUIManager> ();

        nFTSceneObj.SetActive (false);
        nFTSceneObj.transform.localScale = Vector3.one * 0.025f;
    }


    public void SetPutOn (bool putFlag)
    {
        isPutOn = putFlag;
        showTarget ();
        nFTSceneObj.transform.localScale = Vector3.one * 0.025f;
    }

    /// <summary>
    /// 设置目标对象显示Scale
    /// </summary>
    /// <param name="scaleValue"></param>
    public void OnChangeScale (float scaleValue)
    {
        nFTSceneObj.transform.localScale = Vector3.one * scaleValue;
    }

    private void showTarget ()
    {
        if (!isPutOn)
        {
            aRPlaneManager.enabled = true;
        }
        else
        {
            aRPlaneManager.enabled = false;
        }

        showARPlanes (aRPlaneManager.enabled);
    }

    /// <summary>展示检测到的平面</summary>
    private void showARPlanes (bool value)
    {
        //Debug.Log ("showARPlanes value:" + value);
        foreach (var plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive (value);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (!isPutOn)
        {
            if (arRaycastManager.Raycast (centerV2, hits, TrackableType.PlaneWithinPolygon))
            {
                // 列表中元素是按命中的距离排序的，所以第一个命中的距离是最近的。
                var hitPose = hits [0].pose;
                if (!nFTSceneObj.activeSelf)
                {
                    nFTSceneObj.SetActive (true);
                    nftUIManager.ShowPutBtn (true);
                }

                nFTSceneObj.transform.position = hitPose.position;
                nFTSceneObj.transform.LookAt (Camera.main.transform);
                nFTSceneObj.transform.rotation = Quaternion.Euler (new Vector3 (0, nFTSceneObj.transform.rotation.eulerAngles.y, 0));
            }
        }

    }
}
