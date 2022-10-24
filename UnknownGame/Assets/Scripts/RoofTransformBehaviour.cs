using System.Collections;
using UnityEngine;

public class RoofTransformBehaviour : MonoBehaviour
{
    public Vector3Data parentV3;
    public Vector3Data roofV3;
    private WaitForFixedUpdate wffu;
    public BoolData canRun;
    
    
    public void ResetToZero()
    {
        transform.position = Vector3.zero;
    }

    private void SetRoofV3Value()
    {
        roofV3.value = parentV3.value;
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
