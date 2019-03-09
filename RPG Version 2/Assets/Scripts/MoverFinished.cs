using UnityEngine;
using UnityEngine.AI;

public class MoverFinished : MonoBehaviour {

    void Update() {
        if (Input.GetMouseButton(0)) {
            MoveToCursor();
        }
    }

    void MoveToCursor() {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit)) {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }
}
