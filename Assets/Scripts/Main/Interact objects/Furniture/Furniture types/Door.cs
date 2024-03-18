using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isDoorFree, isOpening;
    private static float rotationSpeed = 70.0f;
    void Start()
    {
        isOpening = true;
        isDoorFree = true;
    }
    public void DoAction()
    {
        if (isDoorFree)
        {
            isDoorFree = false;
            StartCoroutine(OpenCloseDoor());
        }
    }
    private IEnumerator OpenCloseDoor()
    {
        if (isOpening)
        {
            while (transform.rotation.eulerAngles.y < 90)
            {
                yield return null;
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            while (transform.rotation.eulerAngles.y > 2)
            {
                yield return null;
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * -1);
            }
        }
        isOpening = !isOpening;
        isDoorFree = true;
        yield return null;
    }
}
