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

    private bool hasAudioPlayed = false;

	void Start () {
        originalPosition = movingObject.transform.position;
        moveSpeed = Vector3.Distance(originalPosition, moveDestination) / moveTimeSeconds;

		entranceSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (isMoving) {
            //AudioSource audio = GetComponent<AudioSource>();
            // audio.Play();
            if (movingObject != null) {
                movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, moveDestination, moveTimeSeconds * Time.deltaTime);
                if (movingObject.transform.position == moveDestination) {
                    isMoving = false;
                }
            }
        }
	}

  //  void OnTriggerEnter(Collider target) {

		//entranceSource.PlayOneShot (entranceSound);

  //      if (target.tag == "Player") {

  //          isMoving = true;



  //      }
  //  }

    void OnTriggerStay(Collider target) {
        if (target.tag == "Player") {
            if (hasAudioPlayed == false && entranceSource != null) {
                entranceSource.PlayOneShot(entranceSound);
                hasAudioPlayed = true;
            }
            isMoving = true;
        }
    }
}
