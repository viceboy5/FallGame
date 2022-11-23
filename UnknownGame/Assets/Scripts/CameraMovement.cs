//copied from energy980 on Unity Forum https://forum.unity.com/threads/how-to-make-the-camera-only-follow-the-players-x-axis-and-ignore-the-y-axis.833371/


using UnityEngine;
 
public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float offset;
    
    void Update()
    {
        transform.position = new Vector3(target.position.x - offset, transform.position.y, -10);
    }
}
