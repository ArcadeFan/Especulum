using System.Collections;

using UnityEngine;

public class Inventory : MonoBehaviour {


    public DBObjects DB;
    public InventoryObjects[] objetos = new InventoryObjects[2];
    public int[] cantidad = new int[2]; 

    public void AgregarObjeto(int ID)
    {
        for(int i=0;i< objetos.Length; i++)
        {

            if (objetos[i].objeto == null)
            {
                InventoryObjects.Asignar(objetos[i], DB.Database[ID]);
                cantidad[i]++;
                return;

            }
            else
            {
                if (objetos[i].objeto == DB.Database[ID].objeto)
                {
                    cantidad[i]++;
                    return;
                }
            }
        }
        print("no hay espacio");

    }
    public void Eliminar(int slot)
    {

        InventoryObjects aux = new InventoryObjects();

        if (cantidad[slot] == 0 || cantidad[slot] <0)
        {
            InventoryObjects.Asignar(objetos[slot], aux);
          
        }
        else
        {

            cantidad[slot]--;
            if (cantidad[slot] == 0 || cantidad[slot] < 0)
            {
                InventoryObjects.Asignar(objetos[slot], aux);

            }

        }

    }
    public void Usar(int slot)
    {

        InventoryObjects aux = new InventoryObjects();


        if (objetos[slot].objeto !=null)
        {

            if(objetos[slot].Tipo == Top.consumibles)
            {

                print(objetos[slot].Nombre + " fue usado");

                cantidad[slot]--;
                if (cantidad[slot] == 0 || cantidad[slot] < 0)
                {
                    InventoryObjects.Asignar(objetos[slot], aux);

                }


            }
            else if(objetos[slot].Tipo == Top.Equipo)
            {

                print(objetos[slot].Nombre + " fue equipado");


            }
            else if (objetos[slot].Tipo == Top.ObjetosClave)
            {

                print("no se puede usar");

            }



        }

    }
    public bool Buscar(int ID)
    {
        for(int i = 0;i<objetos.Length;i++)
        {
            if (objetos[i].objeto == DB.Database[ID].objeto)
                return true;
        }
        return false;
    }


}
