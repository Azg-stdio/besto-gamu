using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioNPC : MonoBehaviour
{
    public GameObject[] inventario;
    public int tama;
    public int actual;

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
            obj.transform.parent = gameObject.transform.parent;
            obj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-10, gameObject.transform.position.z);
            actual++;
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