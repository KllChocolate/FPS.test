using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float smoothRotationTime = 5f;

    float currentSpeed;
    float speedVelocity;

    [SerializeField] private GameInput gameInput;
    public Animator animator;
    private Transform mainCameraTransform;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        mainCameraTransform = Camera.main.transform;

    }

    private void Update()
    {
        Vector2 inputDir = gameInput.GetMovementVectorNomalized();

        if (inputDir != Vector2.zero)
        {
            float tragetSpeed = moveSpeed * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, tragetSpeed, ref speedVelocity, 0.1f);

            // Calculate direction towards main camera's forward direction
            Vector3 moveDirection = mainCameraTransform.forward * inputDir.y + mainCameraTransform.right * inputDir.x;
            moveDirection.Normalize();

            // Rotate the player to face the camera's forward direction
            Quaternion targetRotation = Quaternion.LookRotation(mainCameraTransform.forward, Vector3.up);
            transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);

            // Move the player
            transform.Translate(moveDirection * currentSpeed * Time.deltaTime, Space.World);


            animator.SetFloat("x", inputDir.x, 0.05f, Time.deltaTime);
            animator.SetFloat("y", inputDir.y, 0.05f, Time.deltaTime);
        }
        else {
            animator.SetFloat("x", inputDir.x, 0, Time.deltaTime);
            animator.SetFloat("y", inputDir.y, 0, Time.deltaTime);
        }
        Debug.Log(inputDir);
    }


}