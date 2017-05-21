using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBObjects : MonoBehaviour {


    public List<InventoryObjects> Database;

    public GameObject canvasInventario;

    void Start()
    {
        canvasInventario.active = false;
    }

    void Update()
    {
    
        if(Input.GetButtonDown("Jump"))
        {

            canvasInventario.active = !canvasInventario.active;


        }


    }

}
