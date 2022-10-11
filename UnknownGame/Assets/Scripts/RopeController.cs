
using System.Collections;

using UnityEngine;
using UnityEngine.Events;

//Created with video tutorial "Unity 2d Basic Rope Swinging Physics" by 10 Minute Tutorials
public class RopeController : MonoBehaviour
{

    public GameObject ropeShooter;

    public SpringJoint2D rope;
    //public int maxRopeFrameCount;
    private int ropeFrameCount;
    public bool canFire;
    public UnityEvent startFireEvent, endFireEvent;

    public LineRenderer lineRenderer;
    
    public IEnumerator OnMouseDown()
    {
        canFire = true;
        startFireEvent.Invoke();
        yield return new WaitForFixedUpdate();
        
        if (canFire)
        {
            yield return new WaitForFixedUpdate();
            Fire();
            Debug.Log("MouseDown");
            
            /*if (rope != null)
            {
                lineRenderer.enabled = true;
                lineRenderer.SetVertexCount(2);
                lineRenderer.SetPosition(0, ropeShooter.transform.position);
                lineRenderer.SetPosition(1, rope.connectedAnchor);
            }
            else
            {
                lineRenderer.enabled = false;
            }*/
        }
        
    }

    private void OnMouseUp()
    {
        canFire = false;
        GameObject.DestroyImmediate(rope);
        endFireEvent.Invoke();
        
    }

    void LateUpdate()
    {
        if (rope != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetVertexCount(2);
            lineRenderer.SetPosition(0, ropeShooter.transform.position);
            lineRenderer.SetPosition(1, rope.connectedAnchor);
        }
        else
        {
            lineRenderer.enabled = false;
        }
        Debug.Log("this is a mess");
    }

    /*private void FixedUpdate()
    {
        if (rope != null)
        {
            ropeFrameCount++;

            if (ropeFrameCount > maxRopeFrameCount)
            {
                GameObject.DestroyImmediate(rope);
                ropeFrameCount = 0;
            }
        }
    }*/

    void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity);
        
        if (hit.collider != null)
        {
            SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
            newRope.autoConfigureDistance = false;
            newRope.distance = 2;
            newRope.enableCollision = false;
            newRope.frequency = .5f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;
            Debug.Log("Firing");

            GameObject.DestroyImmediate(rope);
            rope = newRope;
            ropeFrameCount = 0;

        }
    }
}

    
