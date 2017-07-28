using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start ()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * 900);
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);

        Destroy(gameObject, 3.0f);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

        }
    }
   
}
