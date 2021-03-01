using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectives2 : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Objectives"))
        {
            objectiveOne.SetActive(true);
            objectiveTwo.SetActive(true);
            objectiveThree.SetActive(true);
            objectiveFour.SetActive(true);

            if (playerScript.cactusTotal == 5)
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
