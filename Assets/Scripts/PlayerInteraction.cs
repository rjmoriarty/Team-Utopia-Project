using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
	// Code for picking up and dropping items.
	// Adapted from Unity3D Tutorial - Pickup and Carry Objects by unitylessons.com at https://www.youtube.com/watch?v=runW-mf1UH0

	GameObject mainCamera;
	bool carrying;
	GameObject carriedObject;
	public float distance;
	public float smooth;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
	}

	// Update is called once per frame
	void Update () {
		if (carrying) {
			carry (carriedObject);
			checkDrop ();
		} else {
			pickup ();
		}
	}

	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
	}
		
	void pickup() {
		// Pickups are attempted when the configurable "Interact" button is pressed. The default key is "E".
		if (Input.GetButtonDown ("Interact")) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if (p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					carriedObject.GetComponent<Rigidbody> ().isKinematic = true;
				}
			}
		}
	}

	void checkDrop() {
		// Drops are attempted when the configurable "Interact" button is pressed. THe default key is "E".
		if (Input.GetButtonDown ("Interact")) {
			dropObject();
		}
	}

	void dropObject() {
		carrying = false;
		carriedObject.GetComponent<Rigidbody> ().isKinematic = false;
		carriedObject = null;
	}
}
