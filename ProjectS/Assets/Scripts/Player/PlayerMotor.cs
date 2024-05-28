using System;
using UnityEngine;
<<<<<<< Updated upstream
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
=======
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    public float speed = 0.0f;
    public float maxSpeed = 100.0f;
    public float acceleration = 5.0f;
    public float deceleration = 2.5f;
    public float rotationSpeed = 2.0f;
    public float tiltAngle = 30.0f;
    public Transform leftPivot;
    public Transform rightPivot;

    private CharacterController controller;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }



    public void Moving(Vector2 currentInput)
    {
        // W-Taste zum Beschleunigen
        if (currentInput.y > 0)
        {
            speed += acceleration * Time.deltaTime;
        }
        else if (speed > 0)
        {
            // Automatisches Abbremsen
            speed -= deceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // A/D-Tasten zum Drehen und Neigen
        float tilt = 0;
        if (currentInput.x < 0)
        {
            if (speed <= 5.0f)
            {
                // Drehen um das linke Kind-Transform bei niedriger Geschwindigkeit
                transform.RotateAround(leftPivot.position, Vector3.up, -rotationSpeed);
            }
            else
            {
                // Drehen und Neigen in die linke Richtung bei höherer Geschwindigkeit
                transform.Rotate(Vector3.up, -rotationSpeed);
                tilt = -tiltAngle;
            }
        }
        else if (currentInput.x > 0)
        {
            if (speed <= 5.0f)
            {
                // Drehen um das rechte Kind-Transform bei niedriger Geschwindigkeit
                transform.RotateAround(rightPivot.position, Vector3.up, rotationSpeed);
            }
            else
            {
                // Drehen und Neigen in die rechte Richtung bei höherer Geschwindigkeit
                transform.Rotate(Vector3.up, rotationSpeed);
                tilt = tiltAngle;
            }
        }

        // Neigen des Motorrads
        Quaternion tiltRotation = Quaternion.Euler(0, 0, tilt);
        transform.rotation = Quaternion.Slerp(transform.rotation, tiltRotation, Time.deltaTime * rotationSpeed);

        controller.Move(transform.forward * (speed * Time.deltaTime));
    }


}
>>>>>>> Stashed changes
