using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float multiplicadorRotacion;
    public float multiplicadorMovimiento;
    public Inventario inventario;
    public bool recoge;
    public bool cercaNPC;
    public GameObject NPC;

    // Start is called before the first frame update
    void Start()
    {
        inventario = (Inventario)gameObject.GetComponent("Inventario");
        recoge = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, v * multiplicadorMovimiento));
        transform.transform.Rotate(0, h * multiplicadorRotacion, 0, Space.Self);
        if (Input.GetKey("space"))
        {
            recoge = true;
        }
        else
        {
            recoge = false;
        }
        if (Input.GetKeyDown("space") && recoge && cercaNPC)
        {
            print(inventario.inventario);
            if (NPC != null && inventario.tieneItem())
            {
                print("entrega a NPC");
                var inventarioNPC = (InventarioNPC)NPC.GetComponent("InventarioNPC");
                inventarioNPC.recibe(inventario.inventario[0]);
                inventario.inventario[0] = null;
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Recogible" && recoge && !cercaNPC)
        {
            print("recoge");
            inventario.agregaItem(collision.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            cercaNPC = true;
            NPC = other.gameObject;
        }


    }

    void OnTriggerExit(Collider other)
    {
        cercaNPC = false;
        NPC = null;
    }
}
    
