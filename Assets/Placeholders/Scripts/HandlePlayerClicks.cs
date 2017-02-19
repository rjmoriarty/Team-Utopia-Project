using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePlayerClicks : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(Camera.main.transform.position, Camera.main.transform.forward);
            // Shouldn't use foreach in Unity because it generates a bunch of garbage, but I'm lazy for this rough cut
            foreach (RaycastHit hit in hits) {
                if (hit.transform.gameObject.tag == "PuzzleButton1") {
                    // Should really cache the game object reference in Start
                    GameObject.Find("SecondElevator").GetComponent<MovePuzzleBarriers>().MoveBarrier();
                } else if (hit.transform.gameObject.tag == "PuzzleButton2") {
                    GameObject.Find("PortalDoor").GetComponent<MovePuzzleBarriers>().MoveBarrier();
                }
            }
        }
    }
}
