using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public static Camera cam;
    public static bool isActiveInventory = true, isActiveInvAgainstInactivePlayer;
    private void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Inventory"));
    }
    private void Update()
    {
        PressedKeys();
    }
    private void PressedKeys()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!PlayerManager.isActivePlayer) isActiveInvAgainstInactivePlayer = true;
            isActiveInventory = false;
            cam.enabled = false;
            SceneManager.SetActiveScene(PlayerManager.curentScene);
            PlayerManager.isActivePlayer = true;
            PlayerManager.thisCamera.enabled = true;
            
            
        }
    }
    
}
