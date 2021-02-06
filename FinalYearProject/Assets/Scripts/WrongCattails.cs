using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongCattails : MonoBehaviour
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
            Debug.Log("Player pressed E");
        }
        else if (other.gameObject.tag == "Player")
        {
            text.SetActive(true);
        }
    }
}
