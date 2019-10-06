using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public Material materialConHijo;

    // Start is called before the first frame update
    void Start()
    {
        inventario = (Inventario)gameObject.GetComponent("Inventario");
        recoge = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, v * multiplicadorMovimiento));
        transform.transform.Rotate(0, h * multiplicadorRotacion, 0, Space.Self);
        */
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
                
                var inventarioNPC = (InventarioNPC)NPC.GetComponent("InventarioNPC");
                if (inventarioNPC.validaObjeto(inventario.inventario[0]))
                {
                    print("entrega a NPC");
                    inventarioNPC.recibe(inventario.inventario[0]);
                    inventario.inventario[0] = null;
                    inventario.actual = 0;
                    restauraresaltaNPC(NPC);
                }

            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {


    }

    void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.tag);
        //print(other.gameObject.name);
        var obj = other.gameObject;
        
        if (obj.tag == "Recogible")
        {
            materialConHijo = ((MeshRenderer)obj.GetComponentInChildren<MeshRenderer>()).material;
            resalta(other.gameObject);
            resaltaConHijo(other.gameObject);
        }
        if (obj.tag == "NPC")
        {
            npcMaterial = ((MeshRenderer)obj.GetComponentInChildren<MeshRenderer>()).material;
            cercaNPC = true;
            NPC = obj;

            resaltaNPC(obj);
        }
        if (obj.tag == "Recogible" && recoge && cercaNPC == false)
        {
            
            inventario.agregaItem(obj);
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Recogible" && recoge && cercaNPC == false)
        {
            print("recoge");
            inventario.agregaItem(other.gameObject);
            restauraMaterial(other.gameObject);
            restauraresaltaConHijo(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        cercaNPC = false;
        NPC = null;
        if (other.gameObject.tag == "NPC")
        {
            restauraresaltaNPC(other.gameObject);
        }
        if (other.gameObject.tag == "Recogible")
        {
            restauraresaltaConHijo(other.gameObject);
        }   
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

            meshR.material.EnableKeyword("_EmissionColor");
            meshR.material.SetColor("_Color", new Color(0.0927F, 0.4852F, 0.2416F, 0.42F));
            print("entra: " + meshR.material.GetColor("_Color"));
            print("entra2: " + npcMaterial.GetColor("_Color"));
            //meshR.sharedMaterial.SetColor("_EmissionColor", new Color(0.0927F, 0.4852F, 0.2416F, 0.42F));
            //meshR.material.SetInt("g_bUnlit", 1); ;
            //print("poscolor: " + meshR.material.GetColor("_EmissionColor"));
            /*
            List<string> props = new List<string>();
            for (int i = 0; i < ShaderUtil.GetPropertyCount(s); ++i)
                props.Add(ShaderUtil.GetPropertyName(s, i) + " - " + i);
            Debug.Log(string.Join("\n", props.ToArray()));
            */

        }

    }

    void restauraresaltaNPC(GameObject npc)
    {
        meshR = (MeshRenderer)npc.GetComponentInChildren<MeshRenderer>();
        
        if (meshR != null)
        {
            //print("mat: "+meshR.material);
            meshR.material.SetColor("_Color", new Color(1F, 1F, 1F, 1F));
            //print("restaura npc: "+npcMaterial);
            //print("post mat: " + meshR.material);
        }
    }

    void resaltaConHijo(GameObject npc)
    {
        meshR = (MeshRenderer)npc.GetComponentInChildren<MeshRenderer>();
        if (meshR != null)
        {
            meshR.material = iluminado;
        }

    }

    void restauraresaltaConHijo(GameObject npc)
    {
        meshR = (MeshRenderer)npc.GetComponentInChildren<MeshRenderer>();

        if (meshR != null)
        {
            meshR.material = materialConHijo;
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
    
