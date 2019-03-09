using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour {

    const string FORWARD_MOVE = "ForwardMove";

    Animator myAnimator = null;
    NavMeshAgent agent = null;

    void Start() {
        myAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        Vector3 globalVelocity = agent.velocity;
        Vector3 velocity = transform.InverseTransformDirection(globalVelocity);
        float speed = velocity.z;
        myAnimator.SetFloat(FORWARD_MOVE, speed);
    }


}
