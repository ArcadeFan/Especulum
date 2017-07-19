using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc1 : MonoBehaviour {


    public Inventory JI;
    public int ID;
    public int IDAdd;
    public DBObjects DB;


    // Use this for initialization
    void Start()
    {

        JI = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        DB = GameObject.Find("DBObjects").GetComponent<DBObjects>();
    }

    // Update is called once per frame
    void Update ()
    {

        

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < JI.objetos.Length; i++)
            {

                /*if (JI.objetos[i].objeto == DB.Database[ID].objeto)
                {
                    Destroy(gameObject);
                }*/

                if (JI.Buscar(ID))
                {

                    //Destroy(gameObject);

                    JI.AgregarObjeto(IDAdd);



                }

            }
            
        }
    }


}
