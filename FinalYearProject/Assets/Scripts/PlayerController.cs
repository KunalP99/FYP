﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float movespeed = 5f;
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

    public GameObject[] bugButtons;

    void Start()
    {
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
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

        bugButtons = GameObject.FindGameObjectsWithTag("BugButton");

        // Each button with the tag "BugButton" will be disabled when clicked
        foreach (GameObject button in bugButtons)
        {
            button.SetActive(false);
        }
    }

    public void takeDamage()
    {
        Time.timeScale = 1;

        currentHealth -= 20;

        healthBar.SetHealth(currentHealth);

        bugButtons = GameObject.FindGameObjectsWithTag("BugButton");

        // Each button with the tag "BugButton" will be disabled when clicked
        foreach (GameObject button in bugButtons)
        {
            button.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Frog")
        {
            currentHealth -= 40;

            healthBar.SetHealth(currentHealth);
        }
    }
}
