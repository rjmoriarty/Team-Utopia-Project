using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictoHighlight : MonoBehaviour {

    [SerializeField]
    private GameObject[] pictograms;
    [SerializeField]
    private Material highlightMaterial;
    private Material startingMaterial;

    void Start() {
        // This assumes all pictograms use the same base material and at least one
        // assigned pictogram
        startingMaterial = pictograms[0].GetComponent<Renderer>().material;
    }

    void OnMouseEnter() {
        for (int i=0; i < pictograms.Length; i++) {
            pictograms[i].GetComponent<Renderer>().material = highlightMaterial;
        }
    }

    void OnMouseExit() {
        for (int i = 0; i < pictograms.Length; i++) {
            pictograms[i].GetComponent<Renderer>().material = startingMaterial;
        }
    }
}
