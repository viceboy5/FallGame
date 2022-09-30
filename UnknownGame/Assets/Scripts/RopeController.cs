using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created with video tutorial "Unity 2d Basic Rope Swinging Physics" by 10 Minute Tutorials
public class RopeController : MonoBehaviour
{

    public GameObject ropeShooter;

    public SpringJoint2D rope;
    public int maxRopeFrameCount;
    private int ropeFrameCount;

    public LineRenderer lineRenderer;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            Debug.Log("MouseDown");
        }
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
            newRope.distance = 1;
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

    
