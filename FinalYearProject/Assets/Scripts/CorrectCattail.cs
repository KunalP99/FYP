using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCattail : MonoBehaviour
{
    public Animator anim;
    public GameObject text;
    public GameObject originalTerrain;
    public GameObject terrainChange;
    public GameObject waterImage;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            // Swap terrain to show water
            originalTerrain.SetActive(false);
            terrainChange.SetActive(true);

            waterImage.SetActive(true);

            Destroy(gameObject);
            anim.SetTrigger("isDigging");
            text.SetActive(false);

            // A way to show that the player chose the correct plant
        }
        else if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
}
