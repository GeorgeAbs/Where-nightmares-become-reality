using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    [SerializeField] private float rotVerticalSpeed = 2.0f;
    private float verticalAngle;
    void LateUpdate()
    {
        GameObject player = GameObject.Find("Player");
        transform.position = player.transform.position;
        transform.rotation = Quaternion.Euler(
            verticalAngle,
            player.transform.rotation.eulerAngles.y,
            player.transform.rotation.eulerAngles.z
            );
        float mouseVertical = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.left, mouseVertical * rotVerticalSpeed);
        verticalAngle = transform.rotation.eulerAngles.x;
        //Debug.Log(Math.Round(1 / Time.deltaTime));
    }
}
