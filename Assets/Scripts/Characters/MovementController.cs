using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters 
{ 
    public class MovementController : MonoBehaviour
    {
        [Header("Camera Control")]
        [SerializeField] private float minY;
        [SerializeField] private float maxY;
        [SerializeField] private float lookSensitivity = 100f; 
        [SerializeField] Transform cameraTransform;
        private float rotationX = 0f;

        #region Movement
        [Header("Movement Control")]
        [SerializeField] private float characterSpeed;
        [SerializeField] private float runMultiplier;
        [SerializeField] private float jumpHeight = 0.3f;
        [Tooltip("If true, the player can controll the character even while not grounded")]
        [SerializeField] private bool canWalkInJump = true;

        private Vector3 verticalVelocity;
        private bool running = false;

        public Transform groundCheck;
        [SerializeField] float groundDistance = 0.1f;
        [Tooltip("Selected layer will be considered as ground")]
        public LayerMask groundMask;
         private bool isGrounded = true;
        private bool inJumpMovement = false;
        #endregion

        private CharacterController controller;


        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }


        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            CheckIfGrounded();
            JumpRoutine();
            CalculateVerticalMovement();
            MovementRoutine();
            RotateRoutine();
        }

        private void JumpRoutine() //JUMP INPUT
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2 * -9.81f);
            }
        }

        private void MovementRoutine()
        {
            if (!isGrounded && !canWalkInJump) return;

            float xMovement = Input.GetAxis("Horizontal");
            float zMovement = Input.GetAxis("Vertical");
            CheckRunButton();

            Vector3 movementVector = transform.right * xMovement + transform.forward * zMovement;

            controller.Move(movementVector * Time.deltaTime * characterSpeed * (running?runMultiplier:1));
        }

        private void CheckRunButton()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                running = true;
                return;
            }
            running = false;                
        }

        private void RotateRoutine()
        {
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * lookSensitivity;
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * lookSensitivity;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, minY, maxY);

            cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);

        }

        private void CheckIfGrounded()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


            if (isGrounded && verticalVelocity.y <= 0)
            {
                inJumpMovement = false;
                verticalVelocity.y = -2f;
            }
        }

        private void CalculateVerticalMovement()
        {
            verticalVelocity.y += (2 * -9.81f) * Time.deltaTime;

            controller.Move(verticalVelocity * Time.deltaTime);
        }

    }
}

