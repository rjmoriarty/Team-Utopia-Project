using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePortal : MonoBehaviour {

    [SerializeField]
    private float rotationSpeed;
    private Vector3 rotation;

	void Start () {
	}
	
	void Update () {
        transform.Rotate(0, rotationSpeed, 0);
	}
}
