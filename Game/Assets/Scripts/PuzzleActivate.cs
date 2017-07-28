using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleActivate : MonoBehaviour {

    public GameObject panel;
    public GameObject dialogo1;



    public Inventory JI;
    public int ID;
    //public int IDAdd;
    public DBObjects DB;

    // Use this for initialization
    void Start () {
        JI = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        { for (int i = 0; i < JI.objetos.Length; i++)
            {

                /*if (JI.objetos[i].objeto == DB.Database[ID].objeto)
                {
                    Destroy(gameObject);
                }*/


                if (JI.Buscar(ID))
                {

                    //Destroy(gameObject);

            panel.SetActive(true);




                }
                else { dialogo1.SetActive(true); }


            }

        }
    }
    private void OnTriggerExit(Collider other)
    {

        dialogo1.SetActive(false);
        //   dialogo2.SetActive(false);

    }
}

