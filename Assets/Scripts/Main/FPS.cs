using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private TextMeshProUGUI fps;
    void Start()
    {
        fps = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("showFPS", 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void showFPS()
    {
        fps.text = "FPS: " + Math.Round(1 / Time.deltaTime).ToString();
    }
}
