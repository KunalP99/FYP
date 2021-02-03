using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InsectLog : MonoBehaviour
{
    public GameObject bugButton1;
    public GameObject bugButton2;
    public GameObject bugButton3;

    public TextMeshProUGUI logCounter;

    public Objectives objectiveScript;

    int logInt = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;

            // 3 buttons pop up that the player can click. 2 of the buttons will reduce player health while one will heal the player for a small amount
            bugButton1.SetActive(true);
            bugButton2.SetActive(true);
            bugButton3.SetActive(true);

            // Increment logCounter in objectives script
            logInt = logInt + 1;

            UpdateText();
            Destroy(gameObject);
        }
    }

    void UpdateText()
    {
        logCounter.text = "Logs found: " + logInt + "/5";
    }
}
