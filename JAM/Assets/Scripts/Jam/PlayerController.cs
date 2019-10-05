using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float turnSpeed = 5f;
    
    private CharacterController characterController = null;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        characterController.SimpleMove(movement * moveSpeed * Time.deltaTime);

        if(movement.magnitude > 0)
        { 
           Quaternion newRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation,Time.deltaTime * turnSpeed);
        }
    }
}
