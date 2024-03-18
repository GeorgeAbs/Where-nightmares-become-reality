using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryObjectMover : MonoBehaviour
{
    private static Camera thisCamera;
    private static GameObject thisGameObject;
    private static RaycastHit hitData;
    private static Ray ray;
    private static bool couldBeMoved = false;
    private static Rigidbody objectRB;
    private static BoxCollider objectBC;
    void Start()
    {
        thisCamera = gameObject.GetComponentInChildren<Camera>();
    }
    private void Update()
    {
        if (InventoryManager.isActiveInventory)
        {
            thisGameObject = Raycast();
            if (thisGameObject != null && thisGameObject.CompareTag("To backpack"))
            {
                PressedKeys(thisGameObject);
            }
        }
    }
    void FixedUpdate()
    {
        
        if (couldBeMoved)
        {
            MoveObject(thisGameObject);
        }
    }
    private GameObject Raycast()
    {
        ray = thisCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if (Physics.Raycast(ray, out hitData))
        {
            return hitData.collider.gameObject;
        }
        return null;
    }
    private void PressedKeys(GameObject catchedObject)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            objectRB = catchedObject.GetComponent<Rigidbody>();
            objectBC = catchedObject.GetComponent<BoxCollider>();
            objectRB.useGravity = !objectRB.useGravity;
            //objectBC.isTrigger = !objectBC.isTrigger;
            //objectRB.isKinematic = !objectRB.isKinematic;
            couldBeMoved = !couldBeMoved;
        }
    }
    private void MoveObject(GameObject catchedObject)
    {
        Vector3 v3 = (thisCamera.transform.position + thisCamera.transform.forward * 2 - objectRB.position) * 5;
        objectRB.velocity = new Vector3(v3.x, v3.y, v3.z);
    }
}
