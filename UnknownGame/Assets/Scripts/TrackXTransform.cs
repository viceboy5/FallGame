using UnityEngine;


[RequireComponent(typeof(Transform))]
public class TrackXTransform : MonoBehaviour
{
    public Vector3Data playerPosition;
    public IntData xTransform;

    void Update()
    {
        xTransform.value = (int)playerPosition.value[0];
    }
}
