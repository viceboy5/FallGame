using UnityEngine;

public class ConstantMovement2DBehaviour : MonoBehaviour
{
    public FloatData speed;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed.value);
    }
}
