
using UnityEngine;
using System;


public enum Top{consumibles,Equipo,ObjetosClave}


[System.Serializable]

public class InventoryObjects {

    public string Nombre;
    public Top Tipo;
    public string Descripcion;
    public Sprite sprite;
    public GameObject objeto;

    public static void Asignar(InventoryObjects de, InventoryObjects a)
    {

        de.Nombre = a.Nombre;
        de.Tipo = a.Tipo;
        de.Descripcion = a.Descripcion;
        de.sprite = a.sprite;
        de.objeto = a.objeto;



    }


}
