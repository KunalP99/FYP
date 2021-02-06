using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    public GameObject journal;

    public GameObject logText;
    public GameObject lakeText;
    public GameObject unpurifiedTitle;

    public GameObject journalUpdateText;
    public GameObject journalUpdateText2;

    bool journalActive = false;
    bool journalUpdate1 = false;
    bool journalUpdate2 = false;

    // Update is called once per frame
    void Update()
    {
        // Player presses J, time stops and when J is pressed again, time continues
        if (Input.GetKeyDown(KeyCode.J) && journalActive == false)
        {
            // When player triggers a collider, the text is set active, but can only show when the player has the journal active

            // Make the text the child of the journal game object so when it is set active, it'll only show when journal is active
            journal.SetActive(true);
            journalActive = true;
            Time.timeScale = 0;

            if (journalUpdate1 == true)
            {
                logText.SetActive(true);
            }

            if (journalUpdate2 == true)
            {
                lakeText.SetActive(true);
                unpurifiedTitle.SetActive(true);
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
    }
}
