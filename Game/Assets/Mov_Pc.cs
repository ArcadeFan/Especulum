using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Pc : MonoBehaviour {

	public float vel;

	public GameObject _camara;
	public Transform objetivo;
	public float suavidad;

	Vector3 compensar;
	// Use this for initialization
	void Start () 
	{
		compensar = _camara.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"))* vel * Time.deltaTime;
	
	}

	void FixedUpdate ()
	{
		Vector3 ObjetivoCAM = transform.position + compensar; 
		_camara.transform.position = Vector3.Lerp (_camara.transform.position, ObjetivoCAM, suavidad * Time.deltaTime);
	}
}
