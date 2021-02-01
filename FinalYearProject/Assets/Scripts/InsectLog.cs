using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectLog : MonoBehaviour
{
    public GameObject bugButton1;
    public GameObject bugButton2;
    public GameObject bugButton3;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;

            // 3 buttons pop up that the player can click. 2 of the buttons will reduce player health while one will heal the player for a small amount
            bugButton1.SetActive(true);
            bugButton2.SetActive(true);
            bugButton3.SetActive(true);

            Destroy(gameObject);
        }
    }
}
