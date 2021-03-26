using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOS : MonoBehaviour
{
    public GameObject SOSObjective;

    public PlayerController playerScript;

    [HideInInspector] public bool SOSActive = false;

    void OnTriggerStay(Collider other)
    {
        if (playerScript.rockCollected == 10)
        {
            // Objective complete
            SOSObjective.SetActive(true);
            SOSActive = true;
        }
    }
}
