using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float multiplicadorRotacion;
    public float multiplicadorMovimiento;
    public Inventario inventario;

    // Start is called before the first frame update
    void Start()
    {
        inventario = (Inventario) gameObject.GetComponent("Inventario");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0, v*multiplicadorMovimiento));
        transform.transform.Rotate(0, h*multiplicadorRotacion, 0, Space.Self);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Recogible")
        { 
            inventario.agregaItem(collision.gameObject);
        }
    }

}
