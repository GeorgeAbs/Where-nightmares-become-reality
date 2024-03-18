using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSubjectController : MonoBehaviour
{
    static public void SubjectController(GameObject subject)
    {
        switch (subject.tag)
        {
            case "To backpack": BackpackManager.MaintainObject(subject);break;
            case "Movable obstacle":; break;
            case "Furniture": FurnitureManager.ChosingFurniture(subject);break;
        }
    }
}
