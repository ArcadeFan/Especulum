using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {

    public float time;
	// Use this for initialization
	void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime * 900);
        transform.Translate(Vector3.up * Time.deltaTime, Space.World);
        Destroy(gameObject, time);
    }
}
