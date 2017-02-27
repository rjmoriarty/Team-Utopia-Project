using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanHighlight : MonoBehaviour {

    private Color startcolor;

    void OnMouseEnter()
    {
        startcolor = GetComponentInChildren<Renderer>().material.color;
        GetComponentInChildren<Renderer>().material.color = Color.green;
    }
    void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material.color = startcolor;
    }
}
