using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
        }
        /*
        else if (Input.GetMouseButonUp(0);
        {
            StopGrapple();
        }
        */
    }

    void LateUpdate()
    {
        DrawRope();
    }
    

    void StartGrapple()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance)) 
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 6f;
            joint.damper = 5f;
            joint.massScale = 1f;
        }
        
    }

    void DrawRope()
    {
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    void StopGrapple()
    {

    }
    
}
