using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingEnding : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0.8f, 0);
    }
}
