using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Objectives : MonoBehaviour
{
    public GameObject objectiveOne;
    public GameObject objectiveOneComplete;
    public GameObject objectiveTwo;
    public GameObject objectiveTwoComplete;
    public GameObject objectiveThree;
    public GameObject objectiveThreeComplete;
    public GameObject objectiveFour;
    public GameObject objectiveFourComplete;

    public PlayerController playerScript;
    public DesertWater desertWaterScript;

    public TextMeshProUGUI logColour;

    public InsectLog logCount;

    // Update is called once per frame
    void Update()
    {
        // Get button returns true at the frame it was pressed on
        if (Input.GetButton("Objectives"))
        {
            objectiveOne.SetActive(true);
            objectiveTwo.SetActive(true);
            objectiveThree.SetActive(true);
            objectiveFour.SetActive(true);

            // REMEMBER TO DO THE OR CONDITIONS FOR LEVEL 1
            // Shows the text green when conditions are met
            if (playerScript.logTotal == 4 || playerScript.cactusTotal == 5)
            {
                objectiveOneComplete.SetActive(true);
            }
            
            if (playerScript.shelterFound == true)
            {
                objectiveTwoComplete.SetActive(true);
            }
            
            if (playerScript.hillFound == true)
            {
                objectiveThreeComplete.SetActive(true);
            }

            if (desertWaterScript.waterFound2 == true)
            {
                objectiveFourComplete.SetActive(true);
            }
        }
        else if (!Input.GetButton("Objectives"))
        {
            // If tabs is not pressed then don't show objectives
            objectiveOne.SetActive(false);
            objectiveOneComplete.SetActive(false);
            objectiveTwo.SetActive(false);
            objectiveTwoComplete.SetActive(false);
            objectiveThree.SetActive(false);
            objectiveThreeComplete.SetActive(false);
            objectiveFour.SetActive(false);
            objectiveFourComplete.SetActive(false);
        }

    }
}
