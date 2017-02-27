using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToOnEnterTrigger : MonoBehaviour {

    [SerializeField]
    GameObject movingObject;
    [SerializeField]
    private float moveTimeSeconds;
    [SerializeField]
    private Vector3 moveDestination;
    private Vector3 originalPosition;
    private float moveSpeed;
    private bool isMoving;
	public AudioClip entranceSound;
	public AudioSource entranceSource;

	void Start () {
        originalPosition = movingObject.transform.position;
        moveSpeed = Vector3.Distance(originalPosition, moveDestination) / moveTimeSeconds;

		entranceSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (isMoving) {
            //AudioSource audio = GetComponent<AudioSource>();
           // audio.Play();
            movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, moveDestination, moveTimeSeconds * Time.deltaTime);
            if (movingObject.transform.position == moveDestination) {
                isMoving = false;


            }
        }
	}

    void OnTriggerEnter(Collider target) {

		entranceSource.PlayOneShot (entranceSound);

        if (target.tag == "Player") {

            isMoving = true;



        }
    }
}
