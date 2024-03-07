using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCatAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {

    }

    // Update is called once per frame
    void Update ()
    {

    }

    void OnGUI ()
    {
        if (GUI.Button (new Rect (100, 100, 160, 60), "Idle"))
        {
            //GetComponent<Animator> ().SetBool ("Walking", false);
            GetComponent<CatMoveController> ().SetPutOn (new Vector3 (1, 0, 1), Quaternion.identity);
        }

        if (GUI.Button (new Rect (100, 180, 160, 60), "Walk"))
        {
            //GetComponent<Animator> ().SetBool ("Walking", true);
            GetComponent<CatMoveController> ().SetPutOn (new Vector3 (1, 0, -1), Quaternion.identity);
        }
    }
}
