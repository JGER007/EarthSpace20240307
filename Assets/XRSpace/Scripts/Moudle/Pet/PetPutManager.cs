using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPutManager : BasePutManager
{
    [SerializeField]
    private CatMoveController catMoveController;

    public override void SetPutOn (Vector3 position, Quaternion rotation)
    {
        if (!catMoveController.gameObject.activeSelf)
        {
            catMoveController.gameObject.SetActive (true);
            catMoveController.transform.position = position;
            catMoveController.transform.rotation = rotation;
        }
        else
        {
            catMoveController.SetPutOn (position, rotation);
        }
    }
}
