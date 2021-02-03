using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    public GameObject logText;

    // Update is called once per frame
    void Update()
    {
        // Get button returns true at the frame it was pressed on
        if (Input.GetButton("Objectives"))
        {
            logText.SetActive(true);
        }
        else if (!Input.GetButton("Objectives"))
        {
            logText.SetActive(false);
        }
    }
}
