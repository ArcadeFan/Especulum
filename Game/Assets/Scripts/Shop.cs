using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {


    public GameObject UiShop;

	// Use this for initialization
	void Start () {
        UiShop.SetActive(false);



    }

    // Update is called once per frame
    void Update () {


        

		
	}


    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            UiShop.SetActive(true);

        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UiShop.SetActive(false);

        }


    }



}
