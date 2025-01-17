﻿using System.Collections;
using UnityEngine;

public class Leaning : MonoBehaviour
{
    public MouseLook freezeCam;

    [Header("Leaning Values")]
    public float leanDistance = 1f;
    public float leanAngle = 30f;
    public float leanSpeed = 0.1f;

    public Animator anim;

    float leanRightDistance;
    float leanLeftAngle;
    float leanLeftDistance;
    float leanRightAngle;

    [Header("Leaning Height")]
    [SerializeField]
    private float camHeight = 1.4f;
    [SerializeField]
    private float crouchCam = 0.5f;
    public float currentHeight;

    [SerializeField]
    private Crouching crouching;

    private Coroutine moveCoroutine;

    void Start() 
    {
        leanRightDistance = leanDistance;
        leanLeftAngle = leanAngle;
        leanLeftDistance = leanDistance * -1;
        leanRightAngle = leanAngle * -1;
        currentHeight = camHeight;
    }

    void Update()
    {
        if (Input.GetKey("e"))
        {
            anim.SetInteger("Lean", 1);
            freezeCam.canLook = false;
        }

        else if (Input.GetKeyUp("e"))
        {
            anim.SetInteger("Lean", 0);
            freezeCam.canLook = true;
        }

        else if (Input.GetKey("q"))
        {
            anim.SetInteger("Lean", -1);
            freezeCam.canLook = false;
        }

        else if (Input.GetKeyUp("q"))
        {
            anim.SetInteger("Lean", 0);
            freezeCam.canLook = true;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, crouchCam, 0), leanSpeed);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveCoroutine = null;

        }

        if (!crouching.crouchBlocked && moveCoroutine == null)
        { 
            moveCoroutine = StartCoroutine(MoveCamera(new Vector3(0, camHeight, 0), 1.25f));
        }
    }

    private IEnumerator MoveCamera(Vector3 newPosition, float speed)
    {
        Debug.Log("Running");
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, camHeight, 0), t);
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }
}
