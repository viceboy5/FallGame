//started and edited script based on given script on https://tengel403.medium.com/how-create-a-scrolling-background-with-parallax-effect-in-unity-18c070ba149a
using UnityEngine;

public class BackgroundScrollBehaviour : MonoBehaviour
{
    public FloatData scrollSpeed;
    //public Vector3Data startPos;
    private Vector3 startPos;
    public float distance;

    private void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed.value, distance);
        transform.position = startPos + Vector3.right * newPos;
    }
}
