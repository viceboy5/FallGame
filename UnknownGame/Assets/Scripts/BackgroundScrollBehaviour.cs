//started and edited script based on given script on https://tengel403.medium.com/how-create-a-scrolling-background-with-parallax-effect-in-unity-18c070ba149a

using System.Collections;
using UnityEngine;

public class BackgroundScrollBehaviour : MonoBehaviour
{
    public FloatData scrollSpeed;
    public Vector3Data startPos;
    public Vector3Data cameraPos;
    private WaitForFixedUpdate wffu;
    public BoolData canRun;

    public float distance;
    public float modifier;

    public void StartRepeatUntilFalse()
    {
        canRun.value = true;
        StartCoroutine(StartScroll());
    }

    private IEnumerator StartScroll()
    {
        while (canRun.value) 
        {
            Scroll();
            yield return wffu;
        }
    }
    
    private void Scroll()
    {
        
        startPos.value[0] = cameraPos.value[0];
        float newPos = Mathf.Repeat(Time.time * -scrollSpeed.value/modifier, distance);
        transform.position = startPos.value + Vector3.right * newPos;
    }
}
