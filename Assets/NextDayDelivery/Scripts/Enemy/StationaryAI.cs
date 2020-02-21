﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class StationaryAI : EnemyAI
{
    public LayerMask layerMask;
    private Vector3 rotateAwayFromWall = new Vector3(0, 80, 0);
    [SerializeField]
    private float wallCheck = 5;
    [SerializeField]
    private float continueRotation;

    protected override void Patrol()
    {
        agent.SetDestination(patrolPoints[0].transform.position);
        RaycastHit hit;
        Debug.DrawRay(this.transform.position, this.transform.forward * wallCheck, Color.green);

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, wallCheck, layerMask))
        {
            continueRotation = 5f;

        }
        else if (continueRotation >= 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(rotateAwayFromWall * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            continueRotation -= Time.deltaTime;
        }



    }
}