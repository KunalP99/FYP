using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject interactText;
    public GameObject unpurifiedWaterImage;

    [HideInInspector] public bool waterCollected = false;

    public PlayerController playerScript;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            // Display image of water somewhere on screen
            unpurifiedWaterImage.SetActive(true);

            waterCollected = true;

            // Destroy so player cannot keep pressing E on the collider
            Destroy(this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactText.SetActive(true);
        }
    }
}
