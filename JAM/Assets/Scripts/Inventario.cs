using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    public GameObject[] inventario;
    public Image[] imagenes;
    public int tama;
    public int actual = 0;
    public GameObject panel;
    public global globalobj;

    // Start is called before the first frame update
    void Start()
    {

        globalobj = (global) GameObject.Find("GLOBAL").GetComponent("global");
        inventario = new GameObject[tama];
        print(globalobj.inventario.Length);
        if (globalobj.inventario.Length == 0)
        {
            globalobj.inventario = new string[tama];
        }
        else if(globalobj.inventario.Length != 0)
        {
            print("carga");
            for (int i = 0; i < globalobj.inventario.Length; i++)
            {
                if (globalobj.inventario[i] != null)
                {
                    GameObject prefab = buscaPrefab(globalobj.inventario[i]);
                    print("prerf: " + prefab);
                    agregaItem(Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity));
                }
            }
        }
        
        //imagenes = new Image[tama];
    }
    
    public void agregaItem(GameObject obj)
    {
        if (actual < tama)
        {
            inventario[actual] = obj;
            datos item = (datos)obj.GetComponent("datos");
            globalobj.inventario[actual] = item.nombre;
            actual++;
            obj.SetActive(false);
            //print("agrega");
        }
    }

    public void muestraInventario()
    {
        panel.SetActive(!panel.active);
        for(int i = 0; i < tama; i++)
        {
            if (inventario[i] != null)
            {
                datos item = (datos)inventario[i].GetComponent("datos");
                //print(item.nombre);
                switch (item.nombre)
                {
                    case "item1":
                        imagenes[i].sprite = item.imagen;
                        break;
                    case "item2":
                        imagenes[i].sprite = item.imagen;
                        break;
                }
                
            }
        }
    }

    public GameObject buscaPrefab(string nombre)
    {
        for (int i = 0; i < globalobj.prefabsitems.Length; i++){
            datos item = (datos)globalobj.prefabsitems[i].GetComponent("datos");
            if (item.nombre == nombre)
            {
                return globalobj.prefabsitems[i];
            }
        }
        return null;
    }

}
