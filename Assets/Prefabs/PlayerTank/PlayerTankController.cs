using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayerTank {

    public class PlayerTankController : MonoBehaviour {
        public List<WheelCollider> leftWheels;
        public List<WheelCollider> rightWheels;
        public float maxMotorTorque = 400.0f; // maximum torque the motor can apply to wheel
        public float maxSteeringAngle = 30.0f; // maximum steer angle the wheel can have
        public float decelerationForce = 100.0f; // stop force when we are not moving

        public float maxRPM = 5.0f; //Maximum RPM
        
        // finds the corresponding visual wheel
        // correctly applies the transform
        public void ApplyLocalPositionToVisuals(WheelCollider collider)
        {
            if (collider.transform.childCount == 0) {
                return;
            }
        
            Transform visualWheel = collider.transform.GetChild(0);
        
            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);
        
            visualWheel.transform.position = position;
            visualWheel.transform.rotation = rotation;
        }

        public void FixedUpdate()
        {
            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = Input.GetAxis("Horizontal");
            float steeringMotor = maxSteeringAngle;
            
            if (motor != 0f) {
                // We are moving
                float leftMotor = motor;
                float rightMotor = motor;

                if (steering != 0) {
                    if (steering > 0) {
                        rightMotor -= steeringMotor;
                    } else {
                        leftMotor -= steeringMotor;
                    }
                }

                 foreach (WheelCollider wheel in leftWheels) {
                         wheel.brakeTorque = 0;
                        wheel.motorTorque = leftMotor;
                    }

                    foreach (WheelCollider wheel in rightWheels) {
                         wheel.brakeTorque = 0;
                        wheel.motorTorque = rightMotor;
                    }
            } else {
                if (steering != 0) {
                    // Turn
                    if (steering < 0) {
                        // Right Turn
                        steeringMotor = -steeringMotor;
                    }

                    foreach (WheelCollider wheel in leftWheels) {
                         wheel.brakeTorque = 0;
                        wheel.motorTorque = steeringMotor;
                    }

                    foreach (WheelCollider wheel in rightWheels) {
                         wheel.brakeTorque = 0;
                        wheel.motorTorque = -steeringMotor;
                    }
                } else {
                    foreach (WheelCollider wheel in leftWheels) {
                        wheel.brakeTorque = decelerationForce;
                    }

                    foreach (WheelCollider wheel in rightWheels) {
                        wheel.brakeTorque = decelerationForce;
                    }
                }
            }

            UpdateWheels(leftWheels);
            UpdateWheels(rightWheels);
        }

        public void UpdateWheels(List<WheelCollider> wheels) {
            wheels.ForEach(wheel => {
                CorrectWheelRPM(wheel);
                ApplyLocalPositionToVisuals(wheel);
            });
        }

        public void CorrectWheelRPM(WheelCollider wheel) {
            Debug.Log(wheel.rpm);
            if (Math.Abs(wheel.rpm) > maxRPM) {
                wheel.brakeTorque = decelerationForce;
            }
        }
    }
}