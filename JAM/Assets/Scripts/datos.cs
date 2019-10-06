using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datos : MonoBehaviour
{
    // Start is called before the first frame update

    public string nombre;
    public Sprite imagen;
    public Material materialOriginal;
    float timer = 3;
    public float tiempo;
    public bool soltado;
    public CapsuleCollider ignorado;

    void Start()
    {
        try
        {
            materialOriginal = ((MeshRenderer)gameObject.GetComponent("MeshRenderer")).material;
        }
        catch
        {
            materialOriginal = ((MeshRenderer)gameObject.GetComponentInChildren<MeshRenderer>()).material;
        }
        
        soltado = false;
        timer = tiempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (soltado)
        {
            timerCollider();
        }
    }

    void timerCollider()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            print("reinicia item");
            //Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), ignorado, false);
            gameObject.tag = "Recogible";
            soltado = false;
            timer = tiempo;
        }
    }
}
