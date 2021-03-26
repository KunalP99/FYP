using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float movespeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f; // Radius of the sphere that will check if player is on ground
    public LayerMask groundMask; // Control what objects this sphere should check for

    Vector3 velocity;
    bool isGrounded;

    Animator anim;

    public int maxHealth = 100;
    public int currentHealth;
    public Health healthBar;

    [Header("Level 1 variables")]
    public GameObject[] bugButtons;
    public GameObject chooseInsectText;
    public TextMeshProUGUI logCounter;
    public InsectLog logScript;

    [HideInInspector] public int logTotal = 0;
    [HideInInspector] public int waterCollected = 0;

    public GameObject levelCompleteText;

    [Header("Level 2 variables")]
    public bool enableSprint;
    [HideInInspector] public bool shelterFound = false;
    [HideInInspector] public bool hillFound = false;

    public GameObject turnBackText;

    public GameObject[] cactusButtons;

    public int cactusTotal = 0;
    public TextMeshProUGUI cactusCounter;

    public DesertWater desertWaterScript;

    [Header("Level 3 variables")]
    public GameObject[] berryButtons;
    public GameObject chooseBerryText;

    public int rockCollected = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMax(maxHealth);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Freezes player while dig animation is being performed
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dig"))
        {
            return;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Collect"))
        {
            return;
        }

        // Creates an invisible sphere bases on the variables 
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("isJumping", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }

        // SPRINT MECHANIC
        if (Input.GetKey(KeyCode.LeftShift) && enableSprint == true)
        {
            movespeed = 18f;
            anim.SetBool("isSprinting", true);
        }
        else
        {
            movespeed = 12f;
            anim.SetBool("isSprinting", false);
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // We don't want to move the player on the y axis
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Checks if player is moving in any direction
        if (direction.magnitude >= 0.1f)
        {
            anim.SetBool("isJogging", true);

            // Faces the player in the right direction when moving
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            // Makes the rotation smooth
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Gives us direction we want to move in, taking into account the rotation of the camera 
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * movespeed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isJogging", false);
        }

        // Adds velocity to player on the y-axis so that player will fall
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void healHealth()
    {
        Time.timeScale = 1;

        // Adds 20 to health
        currentHealth += 20;

        healthBar.SetHealth(currentHealth);

        chooseInsectText.SetActive(false);

        bugButtons = GameObject.FindGameObjectsWithTag("BugButton");

        // Each button with the tag "BugButton" will be disabled when clicked
        foreach (GameObject button in bugButtons)
        {
            button.SetActive(false);
        }

        // Win condition - need to set buttons active
        if (logTotal == 4 && waterCollected >= 2)
        {
            LevelComplete();
        }
    }

    public void takeDamage()
    {
        Time.timeScale = 1;

        currentHealth -= 20;

        healthBar.SetHealth(currentHealth);

        chooseInsectText.SetActive(false);

        bugButtons = GameObject.FindGameObjectsWithTag("BugButton");

        // Each button with the tag "BugButton" will be disabled when clicked
        foreach (GameObject button in bugButtons)
        {
            button.SetActive(false);
        }

        // Win condition
        if (logTotal == 4 && waterCollected >= 2)
        {
            LevelComplete();
        }
    }

    public void CactusDrink()
    {
        Time.timeScale = 1;

        currentHealth -= 50;
        healthBar.SetHealth(currentHealth);

        cactusButtons = GameObject.FindGameObjectsWithTag("CactusButton");

        foreach (GameObject button in cactusButtons)
        {
            button.SetActive(false);
        }

        if (cactusTotal == 5 && shelterFound == true && hillFound == true && desertWaterScript.waterFound2 == true)
        {
            LevelComplete();
        }
    }

    public void CactusCool()
    {
        Time.timeScale = 1;

        currentHealth += 15;
        healthBar.SetHealth(currentHealth);

        cactusButtons = GameObject.FindGameObjectsWithTag("CactusButton");

        foreach (GameObject button in cactusButtons)
        {
            button.SetActive(false);
        }

        if (cactusTotal == 5 && shelterFound == true && hillFound == true && desertWaterScript.waterFound2 == true)
        {
            LevelComplete();
        }
    }

    public void healBerry()
    {
        Time.timeScale = 1;

        currentHealth += 20;
        healthBar.SetHealth(currentHealth);
        chooseBerryText.SetActive(false);

        berryButtons = GameObject.FindGameObjectsWithTag("BerryButton");

        foreach (GameObject button in berryButtons)
        {
            button.SetActive(false);
        }

    }

    public void hurtBerry()
    {
        Time.timeScale = 1;

        currentHealth -= 50;
        healthBar.SetHealth(currentHealth);
        chooseBerryText.SetActive(false);

        berryButtons = GameObject.FindGameObjectsWithTag("BerryButton");

        foreach (GameObject button in berryButtons)
        {
            button.SetActive(false);
        }
    }

    public void UpdateText()
    {
        logCounter.text = "Logs found: " + logTotal + "/4";
        cactusCounter.text = "Cactuses found: " + cactusTotal + "/5";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Frog")
        {
            currentHealth -= 30;

            healthBar.SetHealth(currentHealth);
        }
        else if (other.gameObject.tag == "Scorpion")
        {
            currentHealth -= 40;

            healthBar.SetHealth(currentHealth);
        }

        if (other.gameObject.tag == "EnableSprint")
        {
            enableSprint = true;
        }  

        if (other.gameObject.tag == "Hill")
        {
            hillFound = true;

            if (cactusTotal == 5 && shelterFound == true && hillFound == true && desertWaterScript.waterFound2 == true)
            {
                LevelComplete();
            }

        }

        if (other.gameObject.tag == "Shelter")
        {
            shelterFound = true;

            if (cactusTotal == 5 && shelterFound == true && hillFound == true && desertWaterScript.waterFound2 == true)
            {
                LevelComplete();
            }
        }

        if (other.gameObject.tag == "Rock")
        {
            rockCollected = rockCollected + 1;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "TurnBack")
        {
            turnBackText.SetActive(true);
        }
        else
        {
            turnBackText.SetActive(false);
        }
    }

    public void LevelComplete()
    {
        levelCompleteText.SetActive(true);

        // Display buttons that allow player to move on to the next level
    }

    void OnTriggerExit(Collider other)
    {
        // This is just to make the turn back text dissappear when the player is not on it
        turnBackText.SetActive(false);
    }
}
