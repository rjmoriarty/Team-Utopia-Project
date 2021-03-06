﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScanController : MonoBehaviour {

	List<Pictogram> learnedPictograms;
	GameObject mainCamera;
	GameObject scanner;
	GameObject screen;
    TextMesh textMesh;
	bool scannerHolstered;
	bool anyPictogramsLearned;
	int selectedPictogramID;

    //Variables to set the scanner rays, play the sound and only emit the particles after a certain point in the sound.
    public GameObject scanRays;
    private GameObject scanRaysObj;
    public Transform scanRaysEmitter;
    public AudioSource scannerSound;
    private float scanInstantiationTimer = 1.5f;
    private bool scanTimer = false;


    private bool displayOnScreen = false;
    public float displayIconTimer = 4f;

    [SerializeField]
    private Material tranparentScreen;

    // Use this for initialization
    void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		learnedPictograms = new List<Pictogram> ();
		scanner = GameObject.Find("scanner01");
		scannerHolstered = false;
		screen = GameObject.Find ("Screen");
        textMesh = GameObject.Find("TextScreen").GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		holster ();
		rotateScannerSelection ();
        scan();
        drawScannerScreen();

		


	}

	void scan() {
		// Scans are attempted when the configurable "Fire1" button is pressed.
		if (Input.GetButtonDown ("Fire1")) {
            scannerSound.Play();

            scanInstantiationTimer = 0.5f;
            scanRaysObj = Instantiate(scanRays, scanRaysEmitter.position, scanRaysEmitter.rotation);
            scanRaysObj.transform.parent = transform;

            Destroy(scanRaysObj, 1.0f);


            // Identify the center of the screen. These ints will be used to form the point for our raycast.
            int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera> ().ScreenPointToRay (new Vector3 (x, y));
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {

                // If our raycast hits an object with the Scannable component, we're in business for scanning.
                if (hit.collider.gameObject.tag == "PictoHistory") {
                    HistoricalPictos h = hit.collider.gameObject.GetComponent<HistoricalPictos>();
                    if (h != null) {
                        setTextOnScanner(h.getPictoMeaning());
                    }
                } else {
                    Scannable s = hit.collider.GetComponent<Scannable>();
                    if (s != null) {
                        // Iterate through each Pictogram from the scanned object and add any unlearned Pictograms to our learnedPictograms list.
                        clearText();

                        foreach (Pictogram p in s.theseSymbols) {
                            Pictogram matchingPictogram = learnedPictograms.Where(o => o.id == p.id).FirstOrDefault();
                            if (matchingPictogram == null) {
                                learnedPictograms.Add(p);
                            }
                        }

                        // The first time we score a succesful scan, put the first learned Pictogram on the screen.
                        if (!anyPictogramsLearned) {
                            Pictogram firstLearnedPictogram = learnedPictograms.FirstOrDefault();
                            selectedPictogramID = firstLearnedPictogram.id;
                            anyPictogramsLearned = true;
                        }
                    }
                }

				BlankPieceController b = hit.collider.GetComponent<BlankPieceController> ();
				if (b != null && learnedPictograms.Count > 0) {
					b.placedPictogram = learnedPictograms.Where (z => z.id == selectedPictogramID).FirstOrDefault ();
				}
			}
		}
	}

	void drawScannerScreen() {
        if (getTextOnScanner() != "") {
            screen.GetComponent<Renderer>().material = tranparentScreen;
        }
		else if (anyPictogramsLearned) {
			Pictogram selectedPictogram = learnedPictograms.Where (x => x.id == selectedPictogramID).FirstOrDefault ();
			Material selectedPictogramSymbol = selectedPictogram.symbol;
			screen.GetComponent<Renderer> ().material = selectedPictogramSymbol;            
        }
	}

	void rotateScannerSelection() {
		if (anyPictogramsLearned) {
			if (Input.GetButtonDown("RotateScanner")) {
                clearText();
				bool pictogramFound = false;
				int pictogramLocatorPosition = selectedPictogramID;
			
				while (!pictogramFound) {
					if (pictogramLocatorPosition >= 30)
					{
						pictogramLocatorPosition = 1;
					} else {
						pictogramLocatorPosition++;
					}
					Pictogram foundPictogram = learnedPictograms.Where (x => x.id == pictogramLocatorPosition).FirstOrDefault();
					if (foundPictogram != null) {
						selectedPictogramID = pictogramLocatorPosition;
						pictogramFound = true;
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

    private void clearText() {
        textMesh.text = "";
    }

    private string getTextOnScanner() {
        return textMesh.text;
    }

    private void setTextOnScanner(string text) {
        // Yep, seriously
        text = text.Replace("NEWLINE", "\n");
        textMesh.text = text;
    }
}
