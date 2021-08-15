using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMover : MonoBehaviour
    {
        [Header("Movement Control")]

        [Min(0)]
        [SerializeField] protected float characterSpeed = 1;

        [SerializeField] protected bool canRun;
        [Min(1)]
        [SerializeField] protected float runMultiplier = 1.5f;
        protected bool running = false;

        [SerializeField] private bool canJump;
        [Min(0.1f)]
        [SerializeField] private float jumpHeight = 0.5f;
        [Tooltip("If true, the player can controll the character even while not grounded")]
        [SerializeField] private bool canWalkInJump = true;
        [SerializeField] Transform groundCheck;
        [Min(0)]
        [SerializeField] float groundDistance = 0.1f;
        [Tooltip("Selected layer will be considered as ground")]
        [SerializeField] LayerMask groundMask;
        private bool isGrounded = true;
        private bool inJumpMovement = false;
        private Vector3 verticalVelocity;

        private CharacterController controller;

        public void SetRunning(bool isRunning) => running = isRunning;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
        }

        void Start()
        {
        
        }
         
        void LateUpdate()
        {
                CheckIfGrounded();
                CalculateVerticalMovement();
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
        public void Jump()
        {
            if (!isGrounded) 
                return;
            verticalVelocity.y = Mathf.Sqrt(jumpHeight * -2 * -9.81f);
        }
        public void CalculateVerticalMovement()
        {
            verticalVelocity.y += (2 * -9.81f) * Time.deltaTime;

            controller.Move(verticalVelocity * Time.deltaTime);
        }
        public void HandleHorizontalMovement(float xMovement, float zMovement)
        {
            if (!isGrounded && !canWalkInJump) return;

            Vector3 moveVector = CalculateHorizontalMovement(xMovement, zMovement);

            controller.Move(moveVector);
        }
        private Vector3 CalculateHorizontalMovement(float xMovement, float zMovement)
        {
            Vector3 movementVector = transform.right * xMovement + transform.forward * zMovement;
            movementVector = movementVector * Time.deltaTime * characterSpeed * (running ? runMultiplier : 1);

            return movementVector;
        }
    }
}
