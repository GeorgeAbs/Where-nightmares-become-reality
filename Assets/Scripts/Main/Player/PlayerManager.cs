using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool actionButtonDo, actionButtonUndo, flashlightButton, slowMovementButton;
    public static int health;
    private GameObject interactObject;
    public static Scene curentScene;
    public static bool isActivePlayer = true;
    public static Camera thisCamera;
    void Start()
    {
        thisCamera = gameObject.GetComponentInChildren<Camera>();
        curentScene = SceneManager.GetActiveScene();
        health = 100;
    }
    void Update()
    {
        if(isActivePlayer)
        {
            PressedKeys();
            interactObject = Raycast();
        }
        else
        {
            thisCamera.enabled = false;
        }
        InventoryManager.isActiveInvAgainstInactivePlayer = false;
    }
    private void PressedKeys()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactObject != null)
            {
                InteractSubjectController.SubjectController(interactObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.I) && !InventoryManager.isActiveInvAgainstInactivePlayer)
        {
            isActivePlayer = false;
            InventoryManager.isActiveInventory = true;
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Inventory"));
            InventoryManager.cam.enabled = true;
        }
    }
    private GameObject Raycast()
    {
        Ray ray = thisCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData))
        {
            return hitData.collider.gameObject;
        }
        return null;
        
    }
    
}
