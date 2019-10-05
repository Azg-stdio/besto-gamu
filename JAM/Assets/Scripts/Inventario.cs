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
    
    public Sprite m2;
    // Start is called before the first frame update
    void Start()
    {
        inventario = new GameObject[tama];
        //imagenes = new Image[tama];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void muestraInventario()
    {
        panel.SetActive(!panel.active);
        for(int i = 0; i < tama; i++)
        {
            if (inventario[i] != null)
            {
                datos item = (datos)inventario[i].GetComponent("datos");
                print(item.nombre);
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
}
