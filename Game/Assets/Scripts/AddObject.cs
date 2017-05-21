using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour {


    public Inventory JI;
    public int ID;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            JI.AgregarObjeto(ID);
            Destroy(gameObject);
        }
    }
}
