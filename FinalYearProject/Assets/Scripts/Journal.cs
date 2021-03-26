using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public GameObject journal;

    [Header("Level 1 Text")]
    public GameObject firstText;
    public GameObject secondText;
    public GameObject thirdText;
    public GameObject fourthText;
    public GameObject fifthText;

    public GameObject journalUpdateText;
    public GameObject journalUpdateText2;
    public GameObject journalUpdateText3;
    public GameObject journalUpdateText4;

    [Header("Level 2 Text")]
    bool journalActive = false;
    bool journalUpdate1 = false;
    bool journalUpdate2 = false;
    bool journalUpdate3 = false;
    bool journalUpdate4 = false;

    // Update is called once per frame
    void Update()
    {
        // Player presses J, time stops and when J is pressed again, time continues
        if (Input.GetKeyDown(KeyCode.J) && journalActive == false)
        {
            // Make the text the child of the journal game object so when it is set active, it'll only show when journal is active
            journal.SetActive(true);
            journalActive = true;
            Time.timeScale = 0;

            if (journalUpdate1 == true)
            {
                firstText.SetActive(true);
            }

            if (journalUpdate2 == true)
            {
                secondText.SetActive(true);
                thirdText.SetActive(true);
            }

            if (journalUpdate3 == true)
            {
                fourthText.SetActive(true);
            }

            if (journalUpdate4 == true)
            {
                fifthText.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.J) && journalActive == true)
        {
            journal.SetActive(false);

            journalActive = false;
            Time.timeScale = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "JournalUpdate1")
        {
            journalUpdateText.SetActive(true);
            journalUpdate1 = true;
        }

        if (other.gameObject.tag == "JournalUpdate2")
        {
            journalUpdateText2.SetActive(true);
            journalUpdate2 = true;
        }

        if (other.gameObject.tag == "JournalUpdate3")
        {
            journalUpdateText3.SetActive(true);
            journalUpdate3 = true;
        }

        if(other.gameObject.tag == "JournalUpdate4")
        {
            journalUpdateText4.SetActive(true);
            journalUpdate4 = true;
        }
    }
}
