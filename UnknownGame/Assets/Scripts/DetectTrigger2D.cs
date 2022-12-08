using UnityEngine;
using UnityEngine.Events;

public class DetectTrigger2D : MonoBehaviour
{
    public UnityEvent triggerEvent;
    public GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void OnTriggerEnter2D(Collider2D other)  // Once the Trigger has been entered record collision in the argument variable "other"
    {
        if (other.gameObject.name == player.name)
            triggerEvent.Invoke();
    }
}