using UnityEngine;
using UnityEngine.UI;

public class CameraScrolling : MonoBehaviour
{
    [SerializeField] private RawImage background;
    [SerializeField] private float x, y;
    public FloatData speed;
    

    // Update is called once per frame
    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x,y) * (speed.value * Time.deltaTime), background.uvRect.size);
    }
}
