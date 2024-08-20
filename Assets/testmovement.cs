using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace RB
{
    public class TankController : MonoBehaviour
    {
        public Transform spoke2; // Back right spoke
        public Transform spoke3; // Back left spoke

        public float speed = 5f;       // Speed of the tank
        public float rotationSpeed = 180f; // Rotation speed in degrees per second

        private void Start()
        {
            // Ensure the spokes are set correctly in the editor or find them in the scene
            if (spoke2 == null) spoke2 = GameObject.Find("RobotRotateSpoke2").transform;
            if (spoke3 == null) spoke3 = GameObject.Find("RobotRotateSpoke3").transform;
        }

        private void Update()
        {
            if (Gamepad.all.Count > 0)
            {
                // Get the gamepad
                Gamepad gamepad = Gamepad.all[0];

                // Read the analog input from the left stick
                Vector2 leftStickInput = gamepad.leftStick.ReadValue();
                // Read the analog input from the right stick
                Vector2 rightStickInput = gamepad.rightStick.ReadValue();

                // Log joystick values
                Debug.Log($"Left Stick Input: {leftStickInput}");
                Debug.Log($"Right Stick Input: {rightStickInput}");

                // Compute movement and rotation
                float leftInput = leftStickInput.y * Math.Abs(leftStickInput.y);  // Use the raw Y-axis input for left stick
                float rightInput = rightStickInput.y * Math.Abs(rightStickInput.y); // Use the raw Y-axis input for right stick

                // Calculate movement based on joystick input
                Vector3 movement = (transform.forward * (leftInput + rightInput)) * Time.deltaTime * speed;

                // Apply movement
                transform.Translate(movement, Space.World);

                // Apply rotation based on the left stick input (rotation around spoke2)
                if (leftInput != 0)
                {
                    RotateAroundPoint(spoke2.position, Vector3.up, leftInput * rotationSpeed * Time.deltaTime);
                }
                
                // Apply rotation based on the right stick input (rotation around spoke3)
                if (rightInput != 0)
                {
                    RotateAroundPoint(spoke3.position, Vector3.up, -rightInput * rotationSpeed * Time.deltaTime);
                }
            }
        }

        private void RotateAroundPoint(Vector3 point, Vector3 axis, float angle)
        {
            // Calculate the direction vector from the point to the tank's position
            Vector3 direction = transform.position - point;
            // Calculate the rotation
            Quaternion rotation = Quaternion.AngleAxis(angle, axis);
            // Rotate the direction vector
            direction = rotation * direction;
            // Apply the new position
            transform.position = point + direction;
            // Apply the rotation to the tank
            transform.Rotate(axis, angle, Space.World);
        }
    }
}
