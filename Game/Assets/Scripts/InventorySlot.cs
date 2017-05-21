using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public int ID;
    public Image child;
    public Mark marcador;
    public Inventory Inventory;
    public Text cantidad;

    public void click()
    {
        if (Inventory.objetos[ID].objeto != null)
        {
            if (marcador.ID != ID)
            {
                marcador.transform.position = transform.position;
                marcador.ID = ID;
            }
            else
            {
                Inventory.Usar(ID);
            }
        }
    }
    void Update()
    {

        child.sprite = Inventory.objetos[ID].sprite;
        cantidad.text = Inventory.cantidad[ID].ToString();
        
    }

}
