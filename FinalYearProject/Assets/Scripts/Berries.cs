using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berries : MonoBehaviour
{
    public GameObject berryButton1;
    public GameObject berryButton2;
    public GameObject chooseBerryText;

    public PlayerController playerScript;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;

            berryButton1.SetActive(true);
            berryButton2.SetActive(true);
            chooseBerryText.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
