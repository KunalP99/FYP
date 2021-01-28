using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectLog : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 3 buttons pop up that the player can click. 2 of the buttons will reduce player health while one will heal the player for a small amount
            Destroy(gameObject);
        }
    }
}
