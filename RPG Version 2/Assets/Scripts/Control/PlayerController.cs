using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control {
    public class PlayerController : MonoBehaviour {

        Mover playerMover = null;
        Fighter playerFighter = null;

        void Start() {
            playerMover = GetComponent<Mover>();
            playerFighter = GetComponent<Fighter>();
        }

        void Update() {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            Debug.Log("Nothing to do");
        }

        bool InteractWithCombat() {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits) {
                CombatTarget target = hit.collider.gameObject.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (Input.GetMouseButtonDown(0)) {
                    playerFighter.Attack(target);
                }
                return true;
            }
            return false;
        }

        bool InteractWithMovement() {
            RaycastHit hit;
            Ray ray = GetMouseRay();
            if (Physics.Raycast(ray, out hit)) {
                if (Input.GetMouseButton(0)) {
                    playerMover.MoveTo(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetMouseRay() {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
