using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmootCamera : MonoBehaviour {


    public GameObject player;

    Vector3 offset = new Vector3(-10,10,-10);

	
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform.position);
        transform.position = player.transform.position + offset;


	}
}
