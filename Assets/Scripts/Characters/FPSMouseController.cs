using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    public class FPSMouseController : MonoBehaviour
    {
        [Header("Camera Control")]
        [SerializeField] private float minY;
        [SerializeField] private float maxY;
        [SerializeField] private float lookSensitivity = 100f;
        [SerializeField] Transform cameraTransform;
        private float rotationX = 0f;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        public void RotateRoutine(float mouseX, float mouseY)
        {
            float resultantMouseX = mouseX * Time.deltaTime * lookSensitivity;
            float resultantMouseY = mouseY * Time.deltaTime * lookSensitivity;

            rotationX -= resultantMouseY;
            rotationX = Mathf.Clamp(rotationX, minY, maxY);

            cameraTransform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
            transform.Rotate(Vector3.up * resultantMouseX);

        }

    }
}


