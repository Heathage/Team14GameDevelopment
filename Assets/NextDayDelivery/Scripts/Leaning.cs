﻿using UnityEngine;

public class Leaning : MonoBehaviour
{
    //public KeyCode leanRightKey = KeyCode.R;
    //public KeyCode leanLeftKey = KeyCode.Q;
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Debug.Log("R");
            
            transform.localRotation = Quaternion.Euler(0f, 0f, -45f);
            transform.localPosition = new Vector3(1, 0, 0);
        }

        else if (Input.GetKeyUp("r"))
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey("q"))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 45f);
            transform.localPosition = new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyUp("q"))
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
        
    }
}