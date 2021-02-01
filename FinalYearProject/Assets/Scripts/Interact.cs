using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject interactText;
    public GameObject unpurifiedWaterImage;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            // Display image of water somewhere on screen
            unpurifiedWaterImage.SetActive(true);

            // Let player know they have to boil water before drinking 

            // Destroy so player cannot keep pressing E on the collider
            Destroy(this);
            Debug.Log("Player pressed E");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            interactText.SetActive(true);
        }
    }
}
