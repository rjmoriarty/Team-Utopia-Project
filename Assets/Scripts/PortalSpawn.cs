using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour {

    public GameObject portalUtopia;
    public GameObject portalReturn;
    public GameObject portalReturnSpawn;
    

	// Use this for initialization
	void Start () {
        Instantiate(portalUtopia, transform.position, transform.rotation);
        Instantiate(portalReturn, portalReturnSpawn.transform.position, portalReturnSpawn.transform.rotation);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
