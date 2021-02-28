using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public Animator anim;

    public GameObject cactusDrink;
    public GameObject cactusCool;
    public GameObject text;

    public PlayerController playerScript;
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 0;

            playerScript.cactusTotal = playerScript.cactusTotal + 1;
            playerScript.UpdateText();

            Destroy(gameObject);
            anim.SetTrigger("isDigging");

            cactusDrink.SetActive(true);
            cactusCool.SetActive(true);
            text.SetActive(false);

        }
        else if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
