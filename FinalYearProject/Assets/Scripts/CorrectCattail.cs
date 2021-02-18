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

    public PlayerController playerScript;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            // Swap terrain to show water
            originalTerrain.SetActive(false);
            terrainChange.SetActive(true);

            waterImage.SetActive(true);

            playerScript.waterCollected = playerScript.waterCollected + 1;

            Destroy(gameObject);
            anim.SetTrigger("isDigging");
            text.SetActive(false);

            if (playerScript.logTotal == 4 && playerScript.waterCollected >= 2)
            {
                playerScript.LevelComplete();
            }
        }
        else if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
}
