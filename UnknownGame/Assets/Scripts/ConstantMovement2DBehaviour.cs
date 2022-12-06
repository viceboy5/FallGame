using System.Collections;
using UnityEngine;

public class ConstantMovement2DBehaviour : MonoBehaviour
{
    public FloatData speed;
    public BoolData CanRun;
    
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    
    
    public void StartMove()
    {
        CanRun.value = true;
        StartCoroutine(MoveRight());
    }
    private IEnumerator MoveRight()
    {
        while (CanRun)
        {
            yield return wffu;
            transform.Translate(Vector2.right * Time.deltaTime * speed.value);
        }
    }
}
