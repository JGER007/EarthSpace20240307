using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARCardControl : MonoBehaviour
{
    public void ToNFTScene ()
    {
        SceneManager.LoadScene ("ARSpaceScene", LoadSceneMode.Single);
    }
}
