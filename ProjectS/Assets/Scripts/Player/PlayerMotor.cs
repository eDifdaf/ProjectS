using System;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class PlayerMotor : MonoBehaviour
{
    // maxPower values
    [SerializeField] private float maxForcePower, maxAngle;
    // Input values -1 to 1
    [SerializeField] public float currentAngle;
    [SerializeField] public float forcePower;
    [SerializeField] private WheelCollider frontWheelCollider, backWheelCollider;
    [SerializeField] private Transform frontWheel, backWheel;
    [SerializeField] public Rigidbody bikeRb;
    [SerializeField] private float leanAngle;
    [SerializeField] public GameObject bike;
    public TextMeshProUGUI textForce;
    public TextMeshProUGUI textSpeed;

    
    
    private void FixedUpdate()
    {
        Drive();
        Steer();
        textForce.text = backWheelCollider.motorTorque.ToString();
        textSpeed.text = bikeRb.velocity.ToString();
    }
    
    public void Drive()
    {
        backWheelCollider.motorTorque = maxForcePower * forcePower;
    }
    
    public void Steer()
    {
        frontWheelCollider.steerAngle = maxAngle * currentAngle;

        /*bike.transform.eulerAngles.y = maxAngle * currentAngle;*/
    }
    
    //todo
    /*private void ApplyForceToBikeRigidbody()
    {
        bikeRb.velocity =
    } */
    

    



}