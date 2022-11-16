using UnityEngine;

public class PositionResetBehaviour : MonoBehaviour
{
    public Vector3Data newPosition;


    public void ResetPosition()
    {
        transform.position = newPosition.value;
    }
}
