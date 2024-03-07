using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform target;//摄像机对象
    // Start is called before the first frame update
    void Start ()
    {
        target = Camera.main.GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 tar = target.position;
        tar.y = transform.position.y;
        transform.LookAt (tar);
    }
}
