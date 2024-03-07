using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class NFTUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject btn_big;
    [SerializeField]
    private GameObject btn_small;

    [SerializeField]
    private GameObject btn_put;
    [SerializeField]
    private GameObject btn_cancelput;
    [SerializeField]

    private NFTPutManager nFTPutManager;

    private bool isBig = true;
    // Start is called before the first frame update
    void Start ()
    {
        btn_put.SetActive (false);
        btn_cancelput.SetActive (false);
        btn_big.SetActive (false);
        btn_small.SetActive (false);

        btn_put.GetComponent<Button> ().onClick.AddListener (delegate
        {
            ShowPutBtn (false);
            nFTPutManager.SetPutOn (true);
            SetIsBig (false);
        });

        btn_cancelput.GetComponent<Button> ().onClick.AddListener (delegate
        {
            ShowPutBtn (true);
            nFTPutManager.SetPutOn (false);
            btn_big.SetActive (false);
            btn_small.SetActive (false);
        });
    }

    public void ChangeToScene (string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }

    public void ShowPutBtn (bool flag)
    {
        btn_put.SetActive (flag);
        btn_cancelput.SetActive (!flag);
    }


    public void SetIsBig (bool flag)
    {
        float scaleValue = 0.025f;
        if (flag)
        {
            scaleValue = 1;
            btn_small.gameObject.SetActive (true);
            btn_big.gameObject.SetActive (false);
        }
        else
        {
            scaleValue = 0.025f;
            btn_small.gameObject.SetActive (false);
            btn_big.gameObject.SetActive (true);
        }

        nFTPutManager.OnChangeScale (scaleValue);
    }

    public void ToArCardScene ()
    {
        SceneManager.LoadScene ("XRCardScene", LoadSceneMode.Single);
    }
}
