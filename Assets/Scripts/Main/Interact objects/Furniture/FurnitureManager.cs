using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public static void ChosingFurniture(GameObject subject)
    {
        if (subject.name.Contains("Door object"))
        {
            subject.GetComponent<Door>().DoAction();
        }
        if (subject.name.Contains("Shalve object"))
        {
            subject.GetComponent<Shalve>().DoAction();
        }
    }
}
