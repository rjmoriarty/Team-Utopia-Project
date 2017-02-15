using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scannable : MonoBehaviour {

	public string scanText;
	public Material scannedMaterial;
	bool scanned;

	// This method is executed by the ScanController script when the GameObject is scanned.
	// If a valid scan occurs, the result is added to an aggregate string in the ScanController, representing a learned pictogram.
	public string checkScan() {
		if (!scanned) {
			scanned = true;
			GetComponent<Renderer> ().material = scannedMaterial;
			return scanText + " ";
		} else {
			return "";
		}
	}
}
