using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScanController : MonoBehaviour {

	List<Pictogram> learnedPictograms;

	GameObject mainCamera;
	GameObject scanner;
	bool scannerHolstered;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		// scanner = findScanner ();
		scanner = GameObject.Find("scanner01");
		scannerHolstered = false;
	}
	
	// Update is called once per frame
	void Update () {
		holster ();
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
				// If our raycast hits an object with the Scannable component (presently a script that does NOTHING!), we're in business.
				Scannable s = hit.collider.GetComponent<Scannable> ();
				if (s != null) {
					// Iterate through each Pictogram from the scanned object and add any unlearned Pictograms to our learnedPictograms list.
					foreach (Pictogram p in s.theseSymbols) {
						Pictogram matchingPictogram = learnedPictograms.Where(o => o.ID == p.ID).FirstOrDefault();
						if (matchingPictogram == null) {
							learnedPictograms.Add(p);
						}
					}
				}
			}
		}
	}

	void holster() {
		if (Input.GetButtonDown ("Holster")) {
			
			scanner.SetActive (scannerHolstered);
			scannerHolstered = !scannerHolstered;
		
		}
	}
}
