using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement {
    public class Mover : MonoBehaviour {

        const string FORWARD_SPEED = "ForwardSpeed";

        NavMeshAgent agent = null;
        Animator myAnimator = null;

        void Start() {
            agent = GetComponent<NavMeshAgent>();
            myAnimator = GetComponent<Animator>();
        }

        void Update() {
            UpdateAnimator();
        }

        public void MoveTo(Vector3 destination) {
            agent.destination = destination;
        }

        void UpdateAnimator() {
            Vector3 velocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float currentSpeed = localVelocity.z;
            myAnimator.SetFloat(FORWARD_SPEED, currentSpeed);
        }
    }
}
