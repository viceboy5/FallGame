using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class RopeController : MonoBehaviour
{
    
    public GameObject ropeShooter;
    public SpringJoint2D rope;
    public BoolData canFire;
    public UnityEvent startFireEvent, endFireEvent;
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();
    public float destroyTime = 5.0f;

    public LineRenderer lineRenderer;


    void Start()
    {
        ropeShooter = GameObject.Find("Player");
    }

    private IEnumerator OnMouseDown()
    {
        canFire.value = true;
        startFireEvent.Invoke();

        yield return wffu;
        
        if (canFire)
        {
            yield return wffu;
            Fire();
        }
        
    }

    private void OnMouseUp()
    {
        lineRenderer.enabled = false;
        canFire.value = false;
        GameObject.Destroy(rope);
        endFireEvent.Invoke();
    }

    private void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity);
        
        if (hit.collider != null)
        {
            rope = ropeShooter.AddComponent<SpringJoint2D>();
            rope.autoConfigureDistance = false;
            rope.distance = direction.magnitude/4;
            rope.enableCollision = false;
            rope.frequency = .5f;
            rope.dampingRatio = .5f;
            rope.connectedAnchor = hit.point;
            rope.enabled = true;
            StartCoroutine(LineRenderer());

        }
    }
    private IEnumerator LineRenderer()
    {
        while (rope != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, ropeShooter.transform.position);
            lineRenderer.SetPosition(1, rope.connectedAnchor);
            yield return wffu;
        }
    }
}

    
