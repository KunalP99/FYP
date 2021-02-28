using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertWater : MonoBehaviour
{
    public GameObject waterIcon;
    public GameObject interactText;
    public Animator anim;
    [HideInInspector] public bool waterFound2 = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            waterIcon.SetActive(true);
            interactText.SetActive(false);
            waterFound2 = true;
            anim.SetTrigger("isCollect");

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
