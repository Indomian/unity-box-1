using UnityEngine;
using System.Collections;
using System.Collections.Generic;
    
public class PlayerController2 : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque = 400.0f; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle = 30.0f; // maximum steer angle the wheel can have
    public float decelerationForce = 100.0f; // stop force when we are not moving
    
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
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                Acceleration(axleInfo, motor);
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

    private void Acceleration (AxleInfo axleInfo, float motor)
	{
		if (motor != 0f)
		{
			axleInfo.leftWheel.brakeTorque = 0;
			axleInfo.rightWheel.brakeTorque = 0;
			axleInfo.leftWheel.motorTorque = motor;
			axleInfo.rightWheel.motorTorque = motor;
		} else
		{
			Deceleration (axleInfo);
		}
	}

	private void Deceleration (AxleInfo axleInfo)
	{
		axleInfo.leftWheel.brakeTorque = decelerationForce;
		axleInfo.rightWheel.brakeTorque = decelerationForce;
	}
}
    
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}