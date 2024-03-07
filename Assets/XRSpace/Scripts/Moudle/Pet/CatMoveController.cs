using UnityEngine;

public class CatMoveController : MonoBehaviour
{
    [SerializeField]
    private Animator catAnimator;
    [SerializeField]
    private GameObject targetMarker;

    private Vector3 moveDirection;

    private Vector3 targetPosition;

    private bool isMoving = false;

    private float accSpeed = 5;
    private float speed = 0.7f;
    private float maxSpeed = 0.7f;

    private int currentAction = -1;



    // Start is called before the first frame update
    void Start ()
    {
        currentAction = 0;
        catAnimator.gameObject.SetActive (false);
        targetMarker.gameObject.SetActive (false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (isMoving)
        {
            if (speed < maxSpeed)
            {
                speed = speed + accSpeed * Time.deltaTime;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
            }


            Vector3 catPostion = transform.position;
            float dis = Vector3.Distance (catPostion, targetPosition);
            if (dis > 0.1f)
            {
                transform.position = transform.position + moveDirection.normalized * Time.deltaTime * speed;
            }
            else
            {
                catAnimator.transform.position = targetPosition;
                isMoving = false;
                SetAction (1);
                isMoving = false;
            }
        }
    }

    public void SetAction (int action)
    {
        if (isMoving && action != 8)
        {
            return;
        }

        currentAction = action;
        catAnimator.SetInteger ("Action", action);
    }


    public void SetPutOn (Vector3 position, Quaternion rotation)
    {
        targetPosition = position;
        targetMarker.transform.position = position;
        targetMarker.transform.rotation = rotation;

        moveDirection = targetPosition - transform.position;
        Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation (moveDirection) : transform.rotation;
        transform.rotation = targetRotation;
        targetMarker.transform.rotation = targetRotation;

        if (Vector3.Distance (transform.position, targetPosition) <= 0.05f)
        {
            transform.position = targetPosition;
            isMoving = false;

        }
        else
        {
            targetMarker.SetActive (true);
            SetAction (8);
            isMoving = true;
            speed = 0;
        }
    }
}
