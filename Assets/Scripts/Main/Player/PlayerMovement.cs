using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizonSpeed = 2.5f, forwardSpeed = 3.8f, rotHorizonSpeed = 2.0f;
    private static Rigidbody playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (PlayerManager.isActivePlayer)
        {
            float forwardInput = Input.GetAxis("Vertical");
            float leftRightInput = Input.GetAxis("Horizontal");
            float mouseHorizon = Input.GetAxis("Mouse X");
            playerRB.transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed * forwardInput);
            playerRB.transform.Translate(Vector3.right * Time.deltaTime * horizonSpeed * leftRightInput);
            transform.Rotate(Vector3.up, mouseHorizon * rotHorizonSpeed);
            //transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed * forwardInput);
            //transform.Translate(Vector3.right * Time.deltaTime * horizonSpeed * leftRightInput);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Room"))
        {
            //forwardSpeed = 0.001f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name.Contains("Room"))
        {
            //forwardSpeed = 3.8f;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
    }*/
}
