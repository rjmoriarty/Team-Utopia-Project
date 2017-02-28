using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingEnding : MonoBehaviour {

    // Update is called once per frame

    [SerializeField]
    private float moveSpeed;

	void Update () {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }
}
