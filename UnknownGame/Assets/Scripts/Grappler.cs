using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public SpringJoint2D springJoint;
    
    // Start is called before the first frame update
    void Start()
    {
        springJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousePos);
            lineRenderer.SetPosition(1, transform.position);
            springJoint.connectedAnchor = mousePos;
            springJoint.enabled = true;
            springJoint.autoConfigureDistance = false;
            springJoint.distance = 2f;
            springJoint.enableCollision = false;
            springJoint.frequency = .5f;
            springJoint.dampingRatio = .5f;
            lineRenderer.enabled = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            springJoint.enabled = false;
            lineRenderer.enabled = false;
        }

        if (springJoint.enabled)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }
}
