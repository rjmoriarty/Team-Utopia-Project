using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenElevatorDoorsAtTop : MonoBehaviour {

    [SerializeField]
    GameObject[] elevatorDoorsToOpen;

	void Start () {
		
	}

    void OnTriggerEnter(Collider target) {
        if (target.tag == "Player") {
            for (int i = 0; i < elevatorDoorsToOpen.Length; i++) {
                elevatorDoorsToOpen[i].SetActive(false);
            }
        }
    }
}
