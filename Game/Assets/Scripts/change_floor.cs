using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_floor : MonoBehaviour {

    public GameObject[] pisos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider collisionInfo)
    {

        


        print("No longer in contact with " + collisionInfo.transform.name);
    }

}

