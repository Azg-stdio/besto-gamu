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
    public Material iluminado;
    public MeshRenderer meshR;
    public Material npcMaterial;

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
        if (Input.GetKeyDown("space"))
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
                inventario.actual = 0;
                restauraresaltaNPC(NPC);
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {


    }

    void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.tag);
        
        if (other.gameObject.tag == "Recogible")
        {
            resalta(other.gameObject);
        }
        if (other.gameObject.tag == "Recogible" && recoge && cercaNPC == false)
        {
            
            inventario.agregaItem(other.gameObject);
        }

        if (other.gameObject.tag == "NPC")
        {
            cercaNPC = true;
            NPC = other.gameObject;
            npcMaterial = ((MeshRenderer)other.gameObject.GetComponentInChildren<MeshRenderer>()).material;
            resaltaNPC(other.gameObject);
        }


    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Recogible" && recoge && cercaNPC == false)
        {
            print("recoge");
            inventario.agregaItem(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        cercaNPC = false;
        if (NPC != null)
        {
            restauraresaltaNPC(other.gameObject);
        }
        NPC = null;
        restauraMaterial(other.gameObject);

    }

    void resalta (GameObject obj)
    {
        meshR = (MeshRenderer) obj.GetComponent("MeshRenderer");
        if (meshR != null)
        {
            meshR.material = iluminado;
        }
        
    }

    void resaltaNPC(GameObject npc)
    {
        meshR = (MeshRenderer)npc.GetComponentInChildren<MeshRenderer>();
        if (meshR != null)
        {
            meshR.material = iluminado;
        }

    }

    void restauraresaltaNPC(GameObject npc)
    {
        meshR = (MeshRenderer)npc.GetComponentInChildren<MeshRenderer>();
        if (meshR != null)
        {
            meshR.material = npcMaterial;
        }
    }

    void restauraMaterial(GameObject obj)
    {
        meshR = (MeshRenderer)obj.GetComponent("MeshRenderer");
        if(meshR == null)
        {
            meshR = (MeshRenderer)obj.GetComponentInChildren<MeshRenderer>();
        }
        datos datos = ((datos)obj.GetComponent("datos"));
        if (meshR != null && datos != null) {
            meshR.material = datos.materialOriginal;
        }
    }
}
    
