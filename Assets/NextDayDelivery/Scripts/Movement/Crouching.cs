﻿using UnityEngine;

public class Crouching : MonoBehaviour
{
    private CharacterController CharacterController;

    public float crouching = 0f;
    public float crouchCam = 0f;

    public float crouchSpeed = 0f;

    public float standing = 0f;
    public float standCam = 0f; 

    public bool crouched = false;
    public bool crouchBlocked = false;

    public KeyCode crouchKey = KeyCode.LeftControl;
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouched = true;
            CharacterController.center = new Vector3(0, -1, 0);
            CharacterController.height = crouching;
        }
        else if (crouchBlocked == true)// && (Input.GetKeyDown(KeyCode.LeftControl)))
        {
            crouched = true;
            CharacterController.center = new Vector3(0, -1, 0);
            CharacterController.height = crouching;
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl) && (crouchBlocked == false))
        {
            crouched = false;
            CharacterController.center = new Vector3(0, 0, 0);
            CharacterController.height = standing;
        }

        crouchBlocked = IsCeilingAbove(1.5f);
    }

    private bool IsCeilingAbove(float distance)
    {
        Debug.DrawRay(transform.position, transform.up * distance, Color.red);
        return Physics.Raycast(transform.position, transform.up, distance);
    }

    public void CrouchBlock()
    {
        crouchBlocked = true;
    }

    public void NotCrouchBlock()
    {
        crouchBlocked = false;
    }
}
