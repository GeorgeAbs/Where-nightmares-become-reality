using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizonSpeed = 2.5f, forwardSpeed = 3.8f, rotHorizonSpeed = 2.0f;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (InventoryManager.isActiveInventory)
        {
            float forwardInput = Input.GetAxis("Vertical");
            float leftRightInput = Input.GetAxis("Horizontal");
            float mouseHorizon = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up, mouseHorizon * rotHorizonSpeed);
            transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed * forwardInput);
            transform.Translate(Vector3.right * Time.deltaTime * horizonSpeed * leftRightInput);
        }
    }
}
