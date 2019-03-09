using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement {
    public class Mover : MonoBehaviour, IAction {

        const string FORWARD_SPEED = "ForwardSpeed";

        NavMeshAgent agent = null;
        Animator myAnimator = null;
        ActionScheduler actionScheduler = null;

        void Start() {
            agent = GetComponent<NavMeshAgent>();
            myAnimator = GetComponent<Animator>();
            actionScheduler = GetComponent<ActionScheduler>();
        }

        void Update() {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination) {
            actionScheduler.StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination) {
            agent.isStopped = false;
            agent.destination = destination;
        }

        public void Cancel() {
            agent.isStopped = true;
        }

        void UpdateAnimator() {
            Vector3 velocity = agent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float currentSpeed = localVelocity.z;
            myAnimator.SetFloat(FORWARD_SPEED, currentSpeed);
        }
    }
}
