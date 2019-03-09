using UnityEngine;
using System.Collections;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat {
    public class Fighter : MonoBehaviour, IAction {

        [SerializeField] float weaponRange = 2f;

        Transform target;
        ActionScheduler actionScheduler = null;
        Mover mover;

        void Start() {
            mover = GetComponent<Mover>();
            actionScheduler = GetComponent<ActionScheduler>();
        }

        void Update() {
            if (!target) return;
            bool isInRange = Vector3.Distance(target.position, transform.position) <= weaponRange;
            if (!isInRange) {
                mover.MoveTo(target.position);
            } else {
                mover.Cancel();
            }
        }

        public void Attack(CombatTarget combatTarget) {
            actionScheduler.StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel() {
            target = null;
        }

    }
}
