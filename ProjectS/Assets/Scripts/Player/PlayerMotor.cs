using System;
using UnityEngine;

using UnityEngine.Serialization;
using TMPro;
using UnityEditor;

public class PlayerMotor : MonoBehaviour
{
    #region Changable values
    [Header("Maximal Geschwindigkeiten")]
    [SerializeField] private float maxDrivingForce, maxBreakingForce;
    
    [Header("Kurven Winkel")]
    [SerializeField] private float maxHorizontalAngle = 45f;
    
    [Header("Hinterrad Rotation = WheelColliderSpeed / diesen Value")]
    [SerializeField] private float backWheelRotationDividend = 30f;
    #endregion

    #region Inputs
    [NonSerialized] public float breakInput, driveInput, steerInput;
    #endregion

    #region Static Variables
    [SerializeField] private WheelCollider frontWheelCollider, backWheelCollider;
    [SerializeField] private Transform backWheelTransform;
    #endregion


    
    private void FixedUpdate()
    {
        Drive();
        KeepUpright();
        Steer();
        Break();
        WheelRotationUpdate();
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
    
    

    #region WheelRotationUpdate

    private void WheelRotationUpdate()
    {
        //Set the X-Rotation of the backWheelTransform to the X-Rotation of the backWheelCollider divided by the backWheelRotationDividend
        backWheelTransform.Rotate(new Vector3(0, 0, -backWheelCollider.rotationSpeed/backWheelRotationDividend));
    }
    
    #endregion

    #region FixingBikeRotation
    
    private void KeepUpright()
    {
        //Set the rotation to keep the bike upright while Driving and Steering
        Quaternion currentRotation = transform.rotation;
        Vector3 currentEulerAngles = currentRotation.eulerAngles;
        currentEulerAngles.z = 0; //Set the Z rotation to zero
        transform.rotation = Quaternion.Euler(currentEulerAngles);
    }
    
    #endregion
}