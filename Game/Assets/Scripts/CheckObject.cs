using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObject : MonoBehaviour {


    public Inventory JI;
    public int ID;

    public DBObjects DB;

    void Start()
    {

        JI = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        DB = GameObject.Find("DBObjects").GetComponent<DBObjects>();
    }
    private void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            Mision();

        }

    }

    void Mision()
    {

        for (int i = 0; i < JI.objetos.Length; i++)
        {

            /*if (JI.objetos[i].objeto == DB.Database[ID].objeto)
            {
                Destroy(gameObject);
            }*/

            if(JI.Buscar(ID))
            {

                //Destroy(gameObject);

                



            }

        }


    }


}
