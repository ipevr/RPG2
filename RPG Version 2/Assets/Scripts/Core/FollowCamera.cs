using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core {
    public class FollowCamera : MonoBehaviour {

        [SerializeField] Transform target = null;

        void LateUpdate() {
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        }
    }
}
