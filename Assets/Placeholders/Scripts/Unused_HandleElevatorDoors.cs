using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleElevatorDoors : MonoBehaviour {

    [SerializeField]
    GameObject[] elevatorDoors;
    private bool elevatorDoorsDown;

	void Start () {
        elevatorDoorsDown = false;
	}
	
    void OnTriggerEnter(Collider target) {
        if (target.tag == "Player") {
            if (elevatorDoorsDown) {
                for (int i = 0; i < elevatorDoors.Length; i++) {
                    elevatorDoors[i].SetActive(true);
                }
                elevatorDoorsDown = false;
            } 
        } else {
            for (int i = 0; i < elevatorDoors.Length; i++) {
                elevatorDoors[i].SetActive(false);
            }
            elevatorDoorsDown = true;
        }
    }
}
