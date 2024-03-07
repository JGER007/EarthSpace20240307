using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionManager : MonoBehaviour
{
    [SerializeField]
    private CatMoveController catMoveController;
    // Start is called before the first frame update
    void Start ()
    {

    }

    public void ChangeToScene (string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }

    public void SetAction (int actionID)
    {
        catMoveController.SetAction (actionID);
    }
}
