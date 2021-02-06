using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectCattail : MonoBehaviour
{
    public Animator anim;
    public GameObject text;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Destroy(gameObject);
            anim.SetTrigger("isDigging");
            text.SetActive(false);

            // A way to show that the player chose the correct plant
            // Could dupliacte plane, and put hole where plant is, and set the object to active once the player presses E on plant
        }
        else if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
}
