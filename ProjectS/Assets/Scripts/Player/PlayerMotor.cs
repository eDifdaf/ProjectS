using System;
using UnityEngine;

using UnityEngine.Serialization;
using TMPro;
using UnityEditor;

public class PlayerMotor : MonoBehaviour
{
    //Max values
    [SerializeField] private float maxDrivingForce, maxBreakingForce;
    [SerializeField] private float maxHorizontalAngle;
    
    //Inputs
    [SerializeField] public float breakInput, driveInput, steerInput;


    //Variables
    [SerializeField] private WheelCollider frontWheelCollider, backWheelCollider;


    
    private void FixedUpdate()
    {
        Drive();
        KeepUpright();
        Steer();
        Break();
    }


    #region Driving
    public void Drive()
    {
        backWheelCollider.motorTorque = maxDrivingForce * driveInput;
    }
    public void Break()
    {
        backWheelCollider.brakeTorque = maxBreakingForce * breakInput;
    }
    #endregion

    #region Steering
    public void Steer()
    {
        frontWheelCollider.steerAngle = maxHorizontalAngle * steerInput;
    }
    #endregion

    #region FixingRotation
    private void KeepUpright()
    {
        // Set the rotation to keep the bike upright while preserving the forward direction
        Quaternion currentRotation = transform.rotation;
        Vector3 currentEulerAngles = currentRotation.eulerAngles;
        currentEulerAngles.z = 0; // Keep the Z rotation to zero to avoid tipping
        transform.rotation = Quaternion.Euler(currentEulerAngles);
    }
    #endregion
}