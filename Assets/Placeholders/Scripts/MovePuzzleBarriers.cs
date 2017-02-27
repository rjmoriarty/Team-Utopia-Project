using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzleBarriers : MonoBehaviour {

    [SerializeField]
    private Vector3 moveDestination;
    [SerializeField]
    private float moveTimeSeconds;
    private float moveSpeed;
    private bool isMoving;
	public AudioClip barrierSound;
	public AudioSource barrierSource;

    void Start () {
        moveSpeed = Vector3.Distance(transform.position, moveDestination) / moveTimeSeconds;

		barrierSource = GetComponent<AudioSource>();
    }
	
	void Update () {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, moveDestination, moveTimeSeconds * Time.deltaTime);
            if (transform.position == moveDestination) {
                isMoving = false;
            }
        }
    }

    public void MoveBarrier() {
        isMoving = true;


		barrierSource.Play ();

    }
}
