using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText : MonoBehaviour
{
    public GameObject jumpText;
    public GameObject bugText;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tutorial")
        {
            jumpText.SetActive(true);
        }
        else if (other.gameObject.tag == "Tutorial2")
        {
            bugText.SetActive(true);
        }
    }
}
