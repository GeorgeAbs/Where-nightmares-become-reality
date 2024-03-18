using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackpackManager : MonoBehaviour
{
    public static void MaintainObject(GameObject usebleThing)
    {
        SceneManager.MoveGameObjectToScene(usebleThing, SceneManager.GetSceneByName("Inventory"));
        usebleThing.transform.position = new Vector3(0, -999, 0);
    }
}
