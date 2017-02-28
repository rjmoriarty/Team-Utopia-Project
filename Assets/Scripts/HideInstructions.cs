using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInstructions : MonoBehaviour {

    [SerializeField]
    private float durationToShowControls;
    private float timeElapsed;
	
	void Update () {
        if (gameObject.activeSelf) {
            if (timeElapsed >= durationToShowControls) {
                gameObject.SetActive(false);
                return;
            }
            timeElapsed += Time.deltaTime;
        }
	}
}
