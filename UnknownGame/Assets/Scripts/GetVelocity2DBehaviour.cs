using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GetVelocity2DBehaviour : MonoBehaviour
{
    public FloatData velocity;
    public BoolData canRun;
    public Rigidbody2D rb;
    private WaitForFixedUpdate wffu;

    private void SetVelocity()
    {
        velocity.value = rb.velocity.x;
    }

    public void StartRepeatUntilFalse()
    {
        canRun.value = true;
        StartCoroutine(SendVelocity());
    }

    private IEnumerator SendVelocity()
    {
        yield return wffu;
        
        while (canRun.value) 
        {
            SetVelocity();
            yield return wffu;
        }
    }
}
