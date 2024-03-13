using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private InputAction drive;
    [SerializeField] private PlayerMotor playerMotor;




    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        //Get your GameKomponents
        


        //set your Evets

        //algemein wenn ich mal was erklären muss => 
        //[ActionMap].[Action].performed/cancled/hold += [context] => what it should do 



    }

    private void FixedUpdate()
    {
        //Movement
        playerMotor.Moving(drive.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        drive = playerInputActions.ByBike.Drive;
        drive.Enable();
    }

    private void OnDisable()
    {
        drive.Disable();
    }


}
