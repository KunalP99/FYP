using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertWater : MonoBehaviour
{
    public GameObject waterIcon;
    public GameObject interactText;
    public Animator anim;
    [HideInInspector] public bool waterFound2 = false;

    public PlayerController playerScript;

    void OnTriggerStay(Collider other)
    {
        // When player presses E, water is collected and objective is complete
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            waterIcon.SetActive(true);
            interactText.SetActive(false);
            waterFound2 = true;
            anim.SetTrigger("isCollect");

            if (playerScript.cactusTotal == 5 && playerScript.shelterFound == true && playerScript.hillFound == true && waterFound2 == true)
            {
                playerScript.LevelComplete();
            }

            Destroy(this);
        }
        else if (other.gameObject.tag == "Player")
        {
            interactText.SetActive(true);
        }
        else
        {
            interactText.SetActive(false);
        }
    }
}
