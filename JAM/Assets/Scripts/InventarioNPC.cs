using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioNPC : MonoBehaviour
{
    public GameObject[] inventario;
    public int tama;
    public int actual;
    public Transform mano;
    public Transform entregaPunto;
    public GameObject recompensa;
    public GameObject esperado;

    // Start is called before the first frame update
    void Start()
    {
        inventario = new GameObject[tama];
        actual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void recibe(GameObject obj)
    {
        if (tieneEspacio())
        {
            inventario[actual] = obj;
            if (mano ==  null)
            {
                obj.transform.parent = gameObject.transform.parent;
                obj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 10, gameObject.transform.position.z);
            }
            else
            {
                obj.transform.parent = mano;
                obj.transform.localPosition = new Vector3(0, 0, 0);
            }
            entrega();
            actual++;
        }
    }

    public void entrega()
    {
        GameObject entrega = Instantiate(recompensa, entregaPunto.position, entregaPunto.rotation);
    }

    public bool validaObjeto(GameObject obj)
    {
        if(obj.name == esperado.name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool tieneEspacio()
    {
        for(int i = 0; i < inventario.Length; i++)
        {
            if (inventario[i] == null)
            {
                return true;
            }
        }
        return false;
    }
}