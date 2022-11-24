//started and edited script based on given script on https://tengel403.medium.com/how-create-a-scrolling-background-with-parallax-effect-in-unity-18c070ba149a
using UnityEngine;

public class BackgroundScrollBehaviour : MonoBehaviour
{
    public FloatData scrollSpeed;
    public Vector3Data startPos;
    public Vector3Data cameraPos;
    private Vector3 backgroundPos;
    
    public float distance;
    public float modifier;

    void Update()
    {
        backgroundPos[0] = startPos.value[0]+ cameraPos.value[0];
        backgroundPos[1] = startPos.value[1];
        backgroundPos[2] = startPos.value[2];
        
        float newPos = Mathf.Repeat(Time.time * -scrollSpeed.value/modifier, distance);
        transform.position = backgroundPos + Vector3.right * newPos;
    }
}
