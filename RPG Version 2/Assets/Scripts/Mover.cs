using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour {

    const string FORWARD_SPEED = "ForwardSpeed";

    NavMeshAgent agent = null;
    Animator myAnimator = null;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            MoveToCursor();
        }
        UpdateAnimator();
    }

    void UpdateAnimator() {
        Vector3 velocity = agent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float currentSpeed = localVelocity.z;
        myAnimator.SetFloat(FORWARD_SPEED, currentSpeed);
    }

    void MoveToCursor() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            agent.destination = hit.point;
        }
    }
}
