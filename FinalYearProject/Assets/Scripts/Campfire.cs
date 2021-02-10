using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public GameObject purifyText;
    public Interact isWaterCollected;

    public GameObject unpurifiedImage;
    public GameObject waterImage;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E) && isWaterCollected.waterCollected == true) 
        {
            unpurifiedImage.SetActive(false);
            waterImage.SetActive(true);
            Debug.Log("Water is purified!!!!");
        }
        else if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E) && isWaterCollected.waterCollected == false)
        {
            Debug.Log("You have not collected water");
        }
        else if (other.gameObject.tag == "Player")
        {
            purifyText.SetActive(true);
        }
    }
}
