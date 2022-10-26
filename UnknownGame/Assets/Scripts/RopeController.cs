using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class RopeController : MonoBehaviour
{
    
    public GameObject ropeShooter;
    public SpringJoint2D rope;
    public bool canFire;
    public UnityEvent startFireEvent, endFireEvent;

    public LineRenderer lineRenderer;


    void Start()
    {
        ropeShooter = GameObject.Find("Player");
    }

    private IEnumerator OnMouseDown()
    {
        canFire = true;
        startFireEvent.Invoke();

        yield return new WaitForFixedUpdate();
        
        if (canFire)
        {
            yield return new WaitForFixedUpdate();
            Fire();
            Debug.Log("MouseDown");
        }
        
    }

    private void OnMouseUp()
    {
        canFire = false;
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
            newRope.distance = 4f;
            newRope.enableCollision = false;
            newRope.frequency = .5f;
            newRope.dampingRatio = .5f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;
            Debug.Log("Firing");

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

        Debug.Log("ewwwww");
    }
}

    
