using System.Collections;
using UnityEngine;

public class PositionTransferBehaviour : MonoBehaviour
{
    public Vector3Data parentV3;
    public Vector3Data childV3;
    private WaitForFixedUpdate wffu;
    public BoolData canRun;
    public float distance;
    
    
    public void ResetToZero()
    {
        transform.position = Vector3.zero;
    }

    private void SetRoofV3Value()
    {
        childV3.value[0] = parentV3.value[0] + distance;
        childV3.value[1] = 1;
        childV3.value[2] = 0;
    }

    public void StartRepeatUntilFalse()
    {
        canRun.value = true;
        StartCoroutine(SendTransform());
    }
    private IEnumerator SendTransform()
    {
        yield return wffu;
        
        while (canRun.value) 
        {
            SetRoofV3Value();

            yield return wffu;
            
        }
    }
}
