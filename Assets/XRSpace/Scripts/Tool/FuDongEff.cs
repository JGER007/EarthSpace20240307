using UnityEngine;

public class FuDongEff : MonoBehaviour
{
    public float zhenFu = 0.1f;//振幅
    public float HZ = 3f;//频率
    private float initPY = 0.2f;

    private void Update ()
    {
        Vector3 p = transform.position;
        float py = Mathf.Sin (Time.fixedTime * Mathf.PI * HZ) * zhenFu + initPY;
        p.y = py;
        transform.position = p;
    }
}
