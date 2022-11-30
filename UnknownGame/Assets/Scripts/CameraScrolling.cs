using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraScrolling : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float x, y;
    public FloatData scrollsSpeed;
    public BoolData canRun;
    private WaitForFixedUpdate wffu;
    
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
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x,y) * (scrollsSpeed.value * Time.deltaTime), background.uvRect.size);
    }
}
