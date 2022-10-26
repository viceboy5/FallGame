using System.Collections;
using UnityEngine;

public class V3PositionUpdater : MonoBehaviour
{
    public Vector3Data parentV3;
    public Vector3Data childV3;
    public Vector3Data child1V3;
    public Vector3Data child2V3;
    public Vector3Data child3V3;
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
        childV3.value[1] = -4;
        childV3.value[2] = 0;
        
        child1V3.value[0] = parentV3.value[0] + distance;
        child1V3.value[1] = -1;
        child1V3.value[2] = 0;
        
        child2V3.value[0] = parentV3.value[0] + distance;
        child2V3.value[1] = -3;
        child2V3.value[2] = 0;
        
        child3V3.value[0] = parentV3.value[0] + distance;
        child3V3.value[1] = -2;
        child3V3.value[2] = 0;
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
