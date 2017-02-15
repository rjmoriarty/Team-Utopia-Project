using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScanController : MonoBehaviour {

	public Text scannedItems;

	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		scannedItems.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		scan ();
	}

	void scan() {
		// Scans are attempted when the configurable "Fire1" button is pressed.
		if (Input.GetButtonDown ("Fire1")) {
			// Identify the center of the screen. These ints will be used to form the point for our raycast.
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera> ().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				// If our raycast hits an object with the Scannable component (presently a script that does NOTHING!), we're in business and we want to alter the object's properties to signify it has been scanned.
				Scannable s = hit.collider.GetComponent<Scannable> ();
				if (s != null) {
					// Executes the scannable objects checkScan script and adds to the pictogram set if valid.
					scannedItems.text = scannedItems.text + s.checkScan();
				}
			}
		}
	}
}
