using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour    
{
    public static global instancia;
    public string[] inventario;
    public GameObject[] prefabsitems;


    void Awake()
    {
        if(instancia == null)
        {
            DontDestroyOnLoad(gameObject);
            instancia = this;
        }else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }

}
