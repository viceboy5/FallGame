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
        canFire.value = false;
        GameObject.DestroyImmediate(rope);
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
            SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
            newRope.autoConfigureDistance = false;
            newRope.distance = direction.magnitude/4;
            newRope.enableCollision = false;
            newRope.frequency = .5f;
            newRope.dampingRatio = .5f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;

            rope = newRope;
           
        }
    }
    private void LateUpdate()
    {
        if (rope != null)
        {
            lineRenderer.enabled = true;
            //lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, ropeShooter.transform.position);
            lineRenderer.SetPosition(1, rope.connectedAnchor);
        }
        else
        {
            lineRenderer.enabled = false;
        }
        
    }
}

    
