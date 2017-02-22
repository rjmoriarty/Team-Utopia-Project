using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlankPieceController : MonoBehaviour {

	public int expectedPictogramID;
	public Pictogram placedPictogram;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		draw ();
	}

	void draw() {
		if (placedPictogram.id != 0) {
			gameObject.GetComponent<Renderer> ().material = placedPictogram.symbol;
		}
	}
}
