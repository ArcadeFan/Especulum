using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour {


    Inventory JI;
    public int ID;

    DBObjects DB;

    void Start()
    {

        JI = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        DB = GameObject.Find("DBObjects").GetComponent<DBObjects>();
    }

    void OnMouseDown()
    {

        for (int i = 0; i < JI.objetos.Length; i++)
        {

            /*if (JI.objetos[i].objeto == DB.Database[ID].objeto)
            {
                Destroy(gameObject);
            }*/

            if(JI.Buscar(ID))
            {
                Destroy(gameObject);
            }

        }


    }


}
