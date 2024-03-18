using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCamera : MonoBehaviour
{
    [SerializeField] private float rotVerticalSpeed = 2.0f;
    private float verticalAngle;
    
    void LateUpdate()
    {
        if (InventoryManager.isActiveInventory)
        {
            float mouseVertical = Input.GetAxis("Mouse Y");
            InventoryManager.cam.transform.Rotate(Vector3.left, mouseVertical * rotVerticalSpeed);
            verticalAngle = transform.rotation.eulerAngles.x;
        }
    }
}
